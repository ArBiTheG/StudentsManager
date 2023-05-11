using StudentsManagerData.Table;
using StudentsManagerData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using System.Windows;
using StudentsManagerApp.ViewModel.Dialogs;
using System.Windows.Media.Imaging;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class SchoolPageViewModel : BasePageViewModel
    {
        private IStudentsData? StudentsData;
        private ObservableCollection<School>? schools;
        public ObservableCollection<School>? Schools
        {
            get { return schools; }
            set
            {
                schools = value;
                OnPropertyChanged(nameof(Schools));
            }
        }

        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем основные данные
            Schools = StudentsData.GetSchools();
        }

        public override void AddField(object? obj)
        {
            if (StudentsData == null) return;

            SchoolDialogViewModel viewModelDialog = new SchoolDialogViewModel(new School(), StudentsData);

            SchoolWindow schoolWindow = new SchoolWindow(viewModelDialog);
            if (schoolWindow.ShowDialog() == true)
            {
                School school = viewModelDialog.School;
                StudentsData.Add(school);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            if (StudentsData == null) return;

            School? school = selected_obj as School;
            if (school == null) return;

            SchoolDialogViewModel viewModelDialog = new SchoolDialogViewModel(school.Clone(), StudentsData);

            SchoolWindow schoolWindow = new SchoolWindow(viewModelDialog);
            if (schoolWindow.ShowDialog() == true)
            {
                school.Copy(viewModelDialog.School);
                StudentsData.Edit(school);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            if (StudentsData == null) return;

            School? school = selected_obj as School;
            if (school == null) return;

            string text = $"Вы действительно хотите удалить запись '{school.FullName}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(school);
                StudentsData.SaveChanges();
            }
        }

        public override void Close()
        {
        }
    }
}
