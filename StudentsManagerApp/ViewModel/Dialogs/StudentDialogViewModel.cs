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
    public class StudentDialogViewModel
    {
        private IStudentsData StudentsData;
        public Student Student { get; set; }
        public ObservableCollection<Person>? Persons { get; private set; }
        public ObservableCollection<Group>? Groups { get; private set; }
        public StudentDialogViewModel(Student student, IStudentsData studentsData)
        {
            Student = student;
            StudentsData = studentsData;
        }
        public void LoadPersons()
        {
            Persons = StudentsData.GetPersons();
        }
        public void LoadGroups()
        {
            Groups = StudentsData.GetGroups();
        }

        RelayCommand? addPersonCommand;
        RelayCommand? addGroupCommand;
        public RelayCommand AddPersonCommand
        {
            get
            {
                return addPersonCommand ?? (addPersonCommand = new RelayCommand((obj) =>
                {
                    PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

                    PersonDialogWindow personWindow = new PersonDialogWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Student.Person = person;
                    }
                }));
            }
        }

        public RelayCommand AddGroupCommand
        {
            get
            {
                return addGroupCommand ?? (addGroupCommand = new RelayCommand((obj) =>
                {
                    GroupDialogViewModel viewModelDialog = new GroupDialogViewModel(new Group(), StudentsData);
                    viewModelDialog.LoadSpecialties();

                    GroupDialogWindow groupWindow = new GroupDialogWindow(viewModelDialog);
                    if (groupWindow.ShowDialog() == true)
                    {
                        Group group = viewModelDialog.Group;
                        StudentsData.Add(group);
                        StudentsData.SaveChanges();
                        Student.Group = group;
                    }
                }));
            }
        }
    }
}
