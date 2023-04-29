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
    public class EmailPageViewModel : BasePageViewModel<Email>
    {
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Emails.Load();
            StudentsContext.Persons.Load();
            PrimaryList = StudentsContext.Emails.Local.ToObservableCollection();
            persons = StudentsContext.Persons.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }


        public override void AddField(object? obj)
        {
            EmailWindow emailWindow = new EmailWindow(new Email(), persons);
            if (emailWindow.ShowDialog() == true)
            {
                Email email = emailWindow.ViewModel.Email;
                StudentsContext.Emails.Add(email);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;
            StudentsContext.Emails.Remove(email);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Email? email = selected_obj as Email;
            if (email == null) return;
            Email vm = email.Clone() as Email;

            EmailWindow emailWindow = new EmailWindow(vm, persons);

            if (emailWindow.ShowDialog() == true)
            {
                email.Load(emailWindow.ViewModel.Email);
                StudentsContext.Emails.Entry(email).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
