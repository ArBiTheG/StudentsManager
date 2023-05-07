using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerApp.ViewModel.Dialogs;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
            StudentDialogViewModel viewModelDialog = new StudentDialogViewModel(new Student(), StudentsData);
            viewModelDialog.LoadPersons();
            viewModelDialog.LoadGroups();

            StudentWindow studentWindow = new StudentWindow(viewModelDialog);
            if (studentWindow.ShowDialog() == true)
            {
                Student student = viewModelDialog.Student;
                StudentsData.Add(student);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Student? student = selected_obj as Student;
            if (student == null) return;

            StudentDialogViewModel viewModelDialog = new StudentDialogViewModel((Student)student.Clone(), StudentsData);
            viewModelDialog.LoadPersons();
            viewModelDialog.LoadGroups();

            StudentWindow studentWindow = new StudentWindow(viewModelDialog);
            if (studentWindow.ShowDialog() == true)
            {
                student.Load(viewModelDialog.Student);
                StudentsData.Edit(student);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Student? student = selected_obj as Student;
            if (student == null) return;

            string text = $"Вы действительно хотите удалить запись '{student.FullName}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(student);
                StudentsData.SaveChanges();
            }
        }
    }
}
