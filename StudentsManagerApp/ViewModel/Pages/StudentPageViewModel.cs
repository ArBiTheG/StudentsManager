using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class StudentPageViewModel: BasePageViewModel<Student>
    {
        private ObservableCollection<Person> persons;
        private ObservableCollection<Group> groups;
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Students.Load();
            StudentsContext.Persons.Load();
            StudentsContext.Groups.Load();
            PrimaryList = StudentsContext.Students.Local.ToObservableCollection();
            persons = StudentsContext.Persons.Local.ToObservableCollection();
            groups = StudentsContext.Groups.Local.ToObservableCollection();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            StudentWindow studentWindow = new StudentWindow(new Student(), persons, groups);
            if (studentWindow.ShowDialog() == true)
            {
                Student student = studentWindow.ViewModel.Student;
                StudentsContext.Students.Add(student);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Student? student = selected_obj as Student;
            if (student == null) return;
            StudentsContext.Students.Remove(student);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Student? student = selected_obj as Student;
            if (student == null) return;
            Student vm = student.Clone() as Student;

            StudentWindow studentWindow = new StudentWindow(vm, persons, groups);

            if (studentWindow.ShowDialog() == true)
            {
                student.Load(studentWindow.ViewModel.Student);
                StudentsContext.Students.Entry(student).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }

    }
}
