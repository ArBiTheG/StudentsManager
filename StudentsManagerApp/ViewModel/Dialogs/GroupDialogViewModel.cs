using StudentsManager;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Dialogs
{
    public class GroupDialogViewModel
    {
        private IStudentsData StudentsData;
        public Group Group { get; set; }
        public ObservableCollection<Specialty> Specialties { get; set; }
        public GroupDialogViewModel(Group group, IStudentsData studentsData) 
        { 
            Group=group;
            StudentsData = studentsData;
            Specialties = studentsData.GetSpecialties();
        }

        RelayCommand? addSpecialtyCommand;
        public RelayCommand AddSpecialtyCommand
        {
            get
            {
                return addSpecialtyCommand ?? (addSpecialtyCommand = new RelayCommand((obj) =>
                {
                    SpecialtyWindow specialtyWindow = new SpecialtyWindow(new Specialty());
                    if (specialtyWindow.ShowDialog() == true)
                    {
                        Specialty specialty = specialtyWindow.ViewModel.Specialty;
                        StudentsData.Add(specialty);
                        StudentsData.SaveChanges();
                        Group.Specialty = specialty;
                    }
                }));
            }
        }
    }
}
