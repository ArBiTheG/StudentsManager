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
    public class DiplomaPageModel : BasePageModel
    {
        public ObservableCollection<Diploma> Diplomas { get; set; }
        public DiplomaPageModel(StudentsContext studentsContext)
        {
            StudentsContext = studentsContext;
            StudentsContext.Diplomas.Load();
            Diplomas = StudentsContext.Diplomas.Local.ToObservableCollection();
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
