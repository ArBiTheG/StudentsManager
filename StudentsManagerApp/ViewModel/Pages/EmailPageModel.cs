using Microsoft.EntityFrameworkCore;
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
    public class EmailPageModel : BasePageModel
    {
        ObservableCollection<Email> emails;
        public ObservableCollection<Email> Emails
        {
            get { return emails; }
            set
            {
                emails = value;
                OnPropertyChanged(nameof(Emails));
            }
        }

        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Emails.Load();
            Emails = StudentsContext.Emails.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            throw new NotImplementedException();
        }

        public override void DeleteField(object? selected_obj)
        {
            throw new NotImplementedException();
        }

        public override void EditField(object? selected_obj)
        {
            throw new NotImplementedException();
        }
    }
}
