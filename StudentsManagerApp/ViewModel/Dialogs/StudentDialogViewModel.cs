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
    public class StudentDialogViewModel
    {
        private IStudentsData StudentsData;
        public Student Student { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public StudentDialogViewModel(Student student, IStudentsData studentsData)
        {
            Student = student;
            StudentsData = studentsData;
            Persons = studentsData.GetPersons();
            Groups = studentsData.GetGroups();
        }

        RelayCommand? addPersonCommand;
        RelayCommand? addGroupCommand;
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
                    GroupWindow groupWindow = new GroupWindow(new Group(), StudentsData);
                    if (groupWindow.ShowDialog() == true)
                    {
                        Group group = groupWindow.ViewModel.Group;
                        StudentsData.Add(group);
                        StudentsData.SaveChanges();
                        Student.Group = group;
                    }
                }));
            }
        }
    }
}
