using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class EmailPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Email> emails;
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            persons = StudentsData.GetPersons();
            // Подгружаем основные данные
            Emails = StudentsData.GetEmails();
        }
        public ObservableCollection<Email> Emails
        {
            get { return emails; }
            set
            {
                emails = value;
                OnPropertyChanged(nameof(Emails));
            }
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }


        public override void AddField(object? obj)
        {
            EmailDialogViewModel viewModelDialog = new EmailDialogViewModel(new Email(), StudentsData);
            viewModelDialog.LoadPersons();

            EmailWindow emailWindow = new EmailWindow(viewModelDialog);
            if (emailWindow.ShowDialog() == true)
            {
                Email email = viewModelDialog.Email;
                StudentsData.Add(email);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;

            EmailDialogViewModel viewModelDialog = new EmailDialogViewModel((Email)email.Clone(), StudentsData);
            viewModelDialog.LoadPersons();

            EmailWindow emailWindow = new EmailWindow(viewModelDialog);
            if (emailWindow.ShowDialog() == true)
            {
                email.Load(viewModelDialog.Email);
                StudentsData.Edit(email);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;

            string text = $"Вы действительно хотите удалить запись '{email.Name}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(email);
                StudentsData.SaveChanges();
            }
        }
    }
}
