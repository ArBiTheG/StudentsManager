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
    public class PersonDialogViewModel
    {
        public Person Person { get; set; }
        public PersonDialogViewModel(Person person)
        {
            Person = person;
        }
    }
}
