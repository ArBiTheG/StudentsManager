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
    public class DiplomaDialogViewModel
    {
        public Diploma Diploma { get; private set; }
        public ObservableCollection<Person> Persons { get; private set; }
        public ObservableCollection<School> Schools { get; private set; }
        public DiplomaDialogViewModel(Diploma diploma, ObservableCollection<Person> persons, ObservableCollection<School> schools)
        {
            Diploma = diploma;
            Persons = persons;
            Schools = schools;
        }
    }
}
