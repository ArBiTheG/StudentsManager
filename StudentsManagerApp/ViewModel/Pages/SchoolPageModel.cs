using StudentsManagerData.Table;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class SchoolPageModel : BasePageModel
    {
        public ObservableCollection<School> Schools { get; set; }
        public SchoolPageModel(StudentsContext studentsContext)
        {
            StudentsContext = studentsContext;
            StudentsContext.Schools.Load();
            Schools = StudentsContext.Schools.Local.ToObservableCollection();
        }

        public override void AddField(object? obj)
        {
            //SchoolWindow schoolWindow = new SchoolWindow(new School());
            //if (schoolWindow.ShowDialog() == true)
            //{
            //    School school = schoolWindow.School;
            //    studentsContext.Schools.Add(school);
            //    studentsContext.SaveChanges();
            //}
            throw new NotImplementedException();
        }

        public override void DeleteField(object? selected_obj)
        {
            //School? school = selected_obj as School;
            //if (school == null) return;
            //studentsContext.Schools.Remove(school);
            //studentsContext.SaveChanges();
            throw new NotImplementedException();
        }

        public override void EditField(object? selected_obj)
        {
            //School? school = selected_obj as School;
            //if (school == null) return;
            //School vm = school.Clone() as School;
            //
            //SchoolWindow schoolWindow = new SchoolWindow(vm);
            //
            //if (schoolWindow.ShowDialog() == true)
            //{
            //    school.Write(schoolWindow.School);
            //    studentsContext.Entry(school).State = EntityState.Modified;
            //    studentsContext.SaveChanges();
            //}
            throw new NotImplementedException();
        }
    }
}
