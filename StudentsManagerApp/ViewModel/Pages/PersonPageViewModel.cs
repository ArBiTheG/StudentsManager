﻿using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class PersonPageViewModel : BasePageViewModel<Person>
    {
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Persons.Load();
            PrimaryList = StudentsContext.Persons.Local.ToObservableCollection();
        }

        public override void Close()
        {
        }

        public override void AddField(object? obj)
        {
            PersonWindow personWindow = new PersonWindow(new Person());
            if (personWindow.ShowDialog() == true)
            {
                Person person = personWindow.ViewModel.Person;
                StudentsContext.Persons.Add(person);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            StudentsContext.Persons.Remove(person);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            Person vm = person.Clone() as Person;

            PersonWindow personWindow = new PersonWindow(vm);

            if (personWindow.ShowDialog() == true)
            {
                person.Load(personWindow.ViewModel.Person);
                StudentsContext.Persons.Entry(person).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
