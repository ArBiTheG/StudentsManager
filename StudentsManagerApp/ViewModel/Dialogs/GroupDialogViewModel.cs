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
        public Group Group { get; set; }
        public ObservableCollection<Specialty> Specialties { get; set; }
        public GroupDialogViewModel(Group group, ObservableCollection<Specialty> specialties) { 
            Group= group;
            Specialties= specialties;
        }
    }
}
