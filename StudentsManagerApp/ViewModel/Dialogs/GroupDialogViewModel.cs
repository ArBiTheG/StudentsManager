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
        public ObservableCollection<Specialty>? Specialties { get; private set; }
        public GroupDialogViewModel(Group group, IStudentsData studentsData) 
        { 
            Group=group;
            StudentsData = studentsData;
        }
        public void LoadSpecialties()
        {
            Specialties = StudentsData.GetSpecialties();
        }

        RelayCommand? addSpecialtyCommand;
        public RelayCommand AddSpecialtyCommand
        {
            get
            {
                return addSpecialtyCommand ?? (addSpecialtyCommand = new RelayCommand((obj) =>
                {
                    SpecialtyDialogViewModel viewModelDialog = new SpecialtyDialogViewModel(new Specialty(), StudentsData);

                    SpecialtyWindow specialtyWindow = new SpecialtyWindow(viewModelDialog);
                    if (specialtyWindow.ShowDialog() == true)
                    {
                        Specialty specialty = viewModelDialog.Specialty;
                        StudentsData.Add(specialty);
                        StudentsData.SaveChanges();
                        Group.Specialty = specialty;
                    }
                }));
            }
        }
    }
}
