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
    public class HobbyDialogViewModel
    {
        private IStudentsData StudentsData;
        public Hobby Hobby { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public HobbyDialogViewModel(Hobby hobby, IStudentsData studentsData)
        {
            Hobby = hobby;
            StudentsData = studentsData;
            Persons = studentsData.GetPersons();
        }

        RelayCommand? addPersonCommand;
        public RelayCommand AddPersonCommand
        {
            get
            {
                return addPersonCommand ?? (addPersonCommand = new RelayCommand((obj) =>
                {
                    PersonWindow personWindow = new PersonWindow(new Person());
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = personWindow.ViewModel.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Hobby.Person = person;
                    }
                }));
            }
        }
    }
}
