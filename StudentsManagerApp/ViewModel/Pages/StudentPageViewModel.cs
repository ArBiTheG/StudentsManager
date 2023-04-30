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
    public class StudentPageViewModel: BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Student> students;
        private ObservableCollection<Person> persons;
        private ObservableCollection<Group> groups;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            persons = StudentsData.GetPersons();
            groups = StudentsData.GetGroups();
            // Подгружаем основные данные
            Students = StudentsData.GetStudents();
        }
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
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
                StudentsData.Add(student);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Student? student = selected_obj as Student;
            if (student == null) return;
            StudentsData.Remove(student);
            StudentsData.SaveChanges();
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
                StudentsData.Edit(student);
                StudentsData.SaveChanges();
            }
        }

    }
}
