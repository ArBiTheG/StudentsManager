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
    public class SchoolPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<School> schools;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Schools = StudentsData.GetSchools();
        }
        public ObservableCollection<School> Schools
        {
            get { return schools; }
            set
            {
                schools = value;
                OnPropertyChanged(nameof(Schools));
            }
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            SchoolWindow schoolWindow = new SchoolWindow(new School());
            if (schoolWindow.ShowDialog() == true)
            {
                School school = schoolWindow.ViewModel.School;
                StudentsData.Add(school);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            School? school = selected_obj as School;
            if (school == null) return;
            StudentsData.Remove(school);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            School? school = selected_obj as School;
            if (school == null) return;
            School vm = school.Clone() as School;

            SchoolWindow schoolWindow = new SchoolWindow(vm);

            if (schoolWindow.ShowDialog() == true)
            {
                school.Load(schoolWindow.ViewModel.School);
                StudentsData.Edit(school);
                StudentsData.SaveChanges();
            }
        }

    }
}
