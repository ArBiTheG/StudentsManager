using StudentsManagerData.Table;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class PhonePageModel : BaseHandleModel
    {
        StudentsContext studentsContext;
        public ObservableCollection<Phone> Phones { get; set; }
        public PhonePageModel(StudentsContext studentsContext)
        {
            this.studentsContext = studentsContext;
            this.studentsContext.Phones.Load();
            Phones = this.studentsContext.Phones.Local.ToObservableCollection();
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
