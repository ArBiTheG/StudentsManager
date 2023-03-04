using Microsoft.EntityFrameworkCore;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class SpecialtyPageModel : BaseHandleModel
    {
        StudentsContext studentsContext;
        public ObservableCollection<Specialty> Specialties { get; set; }
        public SpecialtyPageModel(StudentsContext studentsContext)
        {
            this.studentsContext = studentsContext;
            this.studentsContext.Specialties.Load();
            Specialties = this.studentsContext.Specialties.Local.ToObservableCollection();
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
