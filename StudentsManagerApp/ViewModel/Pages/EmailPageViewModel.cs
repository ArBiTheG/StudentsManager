using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            EmailWindow emailWindow = new EmailWindow(new Email(), StudentsData);
            if (emailWindow.ShowDialog() == true)
            {
                Email email = emailWindow.ViewModel.Email;
                StudentsData.Add(email);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;
            StudentsData.Remove(email);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;
            Email vm = email.Clone() as Email;

            EmailWindow emailWindow = new EmailWindow(vm, StudentsData);

            if (emailWindow.ShowDialog() == true)
            {
                email.Load(emailWindow.ViewModel.Email);
                StudentsData.Edit(email);
                StudentsData.SaveChanges();
            }
        }
    }
}
