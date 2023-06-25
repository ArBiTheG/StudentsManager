using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.Dialogs;
using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
using StudentsManagerData.Tables;
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
        private IStudentsData? StudentsData;
        private ObservableCollection<Person>? persons;

        public ObservableCollection<Person>? Persons
        {
            get { return persons; }
            set
            {
                persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Persons = StudentsData.GetPersons();
        }

        public override void Close()
        {
        }

        public override void AddField(object? obj)
        {
            if (StudentsData == null) return;

            PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

            PersonDialogWindow personWindow = new PersonDialogWindow(viewModelDialog);
            if (personWindow.ShowDialog() == true)
            {
                Person person = viewModelDialog.Person;
                StudentsData.Add(person);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            if (StudentsData == null) return;

            Person? person = selected_obj as Person;
            if (person == null) return;

            PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(person.Clone(), StudentsData);

            PersonDialogWindow personWindow = new PersonDialogWindow(viewModelDialog);
            if (personWindow.ShowDialog() == true)
            {
                viewModelDialog.Person.Copy(person);
                StudentsData.Edit(person);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            if (StudentsData == null) return;

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
