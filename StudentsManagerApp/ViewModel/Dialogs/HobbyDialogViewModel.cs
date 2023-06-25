using StudentsManager;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Tables;
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
        private IStudentsData? StudentsData;
        public Hobby Hobby { get; set; }
        public ObservableCollection<Person>? Persons { get; private set; }
        public HobbyDialogViewModel(Hobby hobby, IStudentsData studentsData)
        {
            Hobby = hobby;
            Persons = studentsData.GetPersons();
            StudentsData = studentsData;
        }

        RelayCommand? addPersonCommand;
        public RelayCommand AddPersonCommand
        {
            get
            {
                return addPersonCommand ?? (addPersonCommand = new RelayCommand((obj) =>
                {
                    if (StudentsData == null) return;

                    PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

                    PersonWindow personWindow = new PersonWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Hobby.Person = person;
                    }
                }));
            }
        }
    }
}
