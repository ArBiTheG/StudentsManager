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
    public class StudentDialogViewModel
    {
        public Student Student { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public StudentDialogViewModel(Student student, ObservableCollection<Person> persons, ObservableCollection<Group> groups)
        {
            Student = student;
            Persons = persons;
            Groups = groups;
        }
    }
}
