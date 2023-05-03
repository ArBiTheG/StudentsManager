using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class PersonPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Persons = StudentsData.GetPersons();
        }
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set
            {
                persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public override void Close()
        {
        }

        public override void AddField(object? obj)
        {
            PersonWindow personWindow = new PersonWindow(new Person(), StudentsData);
            if (personWindow.ShowDialog() == true)
            {
                Person person = personWindow.ViewModel.Person;
                StudentsData.Add(person);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            StudentsData.Remove(person);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            Person vm = person.Clone() as Person;

            PersonWindow personWindow = new PersonWindow(vm, StudentsData);

            if (personWindow.ShowDialog() == true)
            {
                person.Load(personWindow.ViewModel.Person);
                StudentsData.Edit(person);
                StudentsData.SaveChanges();
            }
        }
    }
}
