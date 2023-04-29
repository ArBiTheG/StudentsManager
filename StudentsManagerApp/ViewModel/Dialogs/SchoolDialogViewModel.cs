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
        public School School { get; set; }
        public SchoolDialogViewModel(School school) {
            School = school;
        }
    }
}
