﻿using StudentsManager;
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
    public class RelationDialogViewModel
    {
        private IStudentsData StudentsData;
        public Relation Relation { get; set; }
        public ObservableCollection<Person>? Childs { get; private set; }
        public ObservableCollection<Person>? Parents { get; private set; }
        public RelationDialogViewModel(Relation relation, IStudentsData studentsData)
        {
            Relation = relation;
            StudentsData = studentsData;
        }
        public void LoadChilds()
        {
            Childs = StudentsData.GetPersons();
        }
        public void LoadParents()
        {
            Parents = StudentsData.GetPersons();
        }

        RelayCommand? addChildCommand;
        RelayCommand? addParentCommand;
        public RelayCommand AddChildCommand
        {
            get
            {
                return addChildCommand ?? (addChildCommand = new RelayCommand((obj) =>
                {
                    PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

                    PersonWindow personWindow = new PersonWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Relation.Child = person;
                    }
                }));
            }
        }
        public RelayCommand AddParentCommand
        {
            get
            {
                return addParentCommand ?? (addParentCommand = new RelayCommand((obj) =>
                {
                    PersonDialogViewModel viewModelDialog = new PersonDialogViewModel(new Person(), StudentsData);

                    PersonWindow personWindow = new PersonWindow(viewModelDialog);
                    if (personWindow.ShowDialog() == true)
                    {
                        Person person = viewModelDialog.Person;
                        StudentsData.Add(person);
                        StudentsData.SaveChanges();
                        Relation.Parent = person;
                    }
                }));
            }
        }
    }
}
