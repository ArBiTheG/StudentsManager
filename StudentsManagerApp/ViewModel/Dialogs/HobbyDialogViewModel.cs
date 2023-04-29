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
    public class HobbyDialogViewModel
    {
        public Hobby Hobby { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public HobbyDialogViewModel(Hobby hobby, ObservableCollection<Person> persons)
        {
            Hobby = hobby;
            Persons = persons;
        }
    }
}
