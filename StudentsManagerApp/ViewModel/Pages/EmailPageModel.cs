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
    public class EmailPageModel : PageModel<Email>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Emails.Load();
            PrimaryList = StudentsContext.Emails.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }


        public override void AddField(object? obj)
        {
            EmailWindow emailWindow = new EmailWindow(new Email());
            if (emailWindow.ShowDialog() == true)
            {
                Email email = emailWindow.Email;
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

            EmailWindow emailWindow = new EmailWindow(vm);

            if (emailWindow.ShowDialog() == true)
            {
                email.Write(emailWindow.Email);
                StudentsContext.Emails.Entry(email).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
