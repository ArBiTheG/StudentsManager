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
    public class PhonePageModel : BasePageModel
    {
        public ObservableCollection<Phone> Phones { get; set; }
        public PhonePageModel(StudentsContext studentsContext)
        {
            StudentsContext = studentsContext;
            StudentsContext.Phones.Load();
            Phones = StudentsContext.Phones.Local.ToObservableCollection();
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
