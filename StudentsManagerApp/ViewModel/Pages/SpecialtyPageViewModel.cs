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
    public class SpecialtyPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Specialty> specialties;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Specialties = StudentsData.GetSpecialties();
        }
        public ObservableCollection<Specialty> Specialties
        {
            get { return specialties; }
            set
            {
                specialties = value;
                OnPropertyChanged(nameof(Specialties));
            }
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            SpecialtyWindow specialtyWindow = new SpecialtyWindow(new Specialty(), StudentsData);
            if (specialtyWindow.ShowDialog() == true)
            {
                Specialty specialty = specialtyWindow.ViewModel.Specialty;
                StudentsData.Add(specialty);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;
            StudentsData.Remove(specialty);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Specialty? specialty = selected_obj as Specialty;
            if (specialty == null) return;
            Specialty vm = specialty.Clone() as Specialty;

            SpecialtyWindow specialtyWindow = new SpecialtyWindow(vm, StudentsData);

            if (specialtyWindow.ShowDialog() == true)
            {
                specialty.Load(specialtyWindow.ViewModel.Specialty);
                StudentsData.Edit(specialty);
                StudentsData.SaveChanges();
            }
        }

    }
}
