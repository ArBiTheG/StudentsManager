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
    public class StudentPageModel:BasePageModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public StudentPageModel(StudentsContext studentsContext)
        {
            StudentsContext = studentsContext;
            StudentsContext.Students.Load();
            Students = StudentsContext.Students.Local.ToObservableCollection();
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
