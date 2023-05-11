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
    public class PersonDialogViewModel
    {
        public Person Person { get; private set; }
        public ObservableCollection<School> Schools { get; private set; }
        public PersonDialogViewModel(Person person, IStudentsData studentsData)
        {
            Person = person;
            Schools = studentsData.GetSchools();
        }
    }
}
