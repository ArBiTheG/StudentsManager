using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Dialogs
{
    public class SpecialtyDialogViewModel
    {
        private IStudentsData StudentsData;
        public Specialty Specialty { get; private set; }
        public SpecialtyDialogViewModel(Specialty specialty, IStudentsData studentsData)
        {
            Specialty = specialty;
            StudentsData = studentsData;
        }
    }
}
