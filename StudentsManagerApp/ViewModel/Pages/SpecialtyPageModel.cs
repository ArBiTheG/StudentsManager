using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
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
    public class SpecialtyPageModel : PageModel<Specialty>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Specialties.Load();
            PrimaryList = StudentsContext.Specialties.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            SpecialtyWindow specialtyWindow = new SpecialtyWindow(new Specialty());
            if (specialtyWindow.ShowDialog() == true)
            {
                Specialty specialty = specialtyWindow.Specialty;
                StudentsContext.Specialties.Add(specialty);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;
            StudentsContext.Specialties.Remove(specialty);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;
            Specialty vm = specialty.Clone() as Specialty;

            SpecialtyWindow specialtyWindow = new SpecialtyWindow(vm);

            if (specialtyWindow.ShowDialog() == true)
            {
                specialty.Load(specialtyWindow.Specialty);
                StudentsContext.Entry(specialty).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
