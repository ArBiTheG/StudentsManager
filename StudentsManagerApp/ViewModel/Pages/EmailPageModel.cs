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
    public class EmailPageModel : BaseHandleModel
    {
        StudentsContext studentsContext;
        public ObservableCollection<Email> Emails { get; set; }
        public EmailPageModel(StudentsContext studentsContext)
        {
            this.studentsContext = studentsContext;
            this.studentsContext.Emails.Load();
            Emails = this.studentsContext.Emails.Local.ToObservableCollection();
        }
        public override void Add(object? obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object? selected_obj)
        {
            throw new NotImplementedException();
        }

        public override void Edit(object? selected_obj)
        {
            throw new NotImplementedException();
        }
    }
}
