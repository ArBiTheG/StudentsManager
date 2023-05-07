using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerApp.ViewModel.Dialogs;
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
            PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

            PersonWindow personWindow = new PersonWindow(viewModelDialog);
            if (personWindow.ShowDialog() == true)
            {
                Person person = viewModelDialog.Person;
                StudentsData.Add(person);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;

            PersonDialogViewModel viewModelDialog = new PersonDialogViewModel((Person)person.Clone(), StudentsData);

            PersonWindow personWindow = new PersonWindow(viewModelDialog);
            if (personWindow.ShowDialog() == true)
            {
                person.Load(viewModelDialog.Person);
                StudentsData.Edit(person);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;

            string text = $"Вы действительно хотите удалить запись '{person.FullName}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(person);
                StudentsData.SaveChanges();
            }
        }
    }
}
