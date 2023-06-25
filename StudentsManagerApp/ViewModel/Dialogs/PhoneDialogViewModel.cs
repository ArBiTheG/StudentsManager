using StudentsManager;
using StudentsManagerApp.View.Dialogs;
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
    public class PhoneDialogViewModel
    {
        private IStudentsData? StudentsData;
        public Phone Phone { get; set; }
        public ObservableCollection<Person>? Persons { get; private set; }
        public PhoneDialogViewModel(Phone phone, IStudentsData studentsData)
        {
            Phone = phone;
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

                    PersonDialogWindow personWindow = new PersonDialogWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Phone.Person = person;
                    }
                }));
            }
        }
    }
}
