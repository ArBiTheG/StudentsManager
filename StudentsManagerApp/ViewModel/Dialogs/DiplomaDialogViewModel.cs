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
    public class DiplomaDialogViewModel
    {
        private IStudentsData StudentsData;
        public Diploma Diploma { get; private set; }
        public ObservableCollection<Person>? Persons { get; private set; }
        public ObservableCollection<School>? Schools { get; private set; }
        public DiplomaDialogViewModel(Diploma diploma, IStudentsData studentsData)
        {
            Diploma = diploma;
            StudentsData = studentsData;
        }
        public void LoadPersons()
        {
            Persons = StudentsData.GetPersons();
        }
        public void LoadSchools()
        {
            Schools = StudentsData.GetSchools();
        }

        RelayCommand? addPersonCommand;
        RelayCommand? addSchoolCommand;
        public RelayCommand AddPersonCommand
        {
            get 
            { 
                return addPersonCommand ?? (addPersonCommand = new RelayCommand((obj) =>
                {
                    PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

                    PersonWindow personWindow = new PersonWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Diploma.Person = person;
                    }
                })); 
            }
        }
        public RelayCommand AddSchoolCommand
        {
            get
            {
                return addSchoolCommand ?? (addSchoolCommand = new RelayCommand((obj) =>
                {
                    SchoolDialogViewModel viewModelDialog = new SchoolDialogViewModel(new School(), StudentsData);

                    SchoolWindow schoolWindow = new SchoolWindow(viewModelDialog);
                    if (schoolWindow.ShowDialog() == true)
                    {
                        School school = viewModelDialog.School;
                        StudentsData.Add(school);
                        StudentsData.SaveChanges();
                        Diploma.School = school;
                    }
                }));
            }
        }
    }
}
