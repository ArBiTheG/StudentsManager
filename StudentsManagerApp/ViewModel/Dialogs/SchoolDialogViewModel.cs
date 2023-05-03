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
    public class SchoolDialogViewModel
    {
        private IStudentsData StudentsData;
        public School School { get; private set; }
        public SchoolDialogViewModel(School school, IStudentsData studentsData)
        {
            School = school;
            StudentsData = studentsData;
        }
    }
}
