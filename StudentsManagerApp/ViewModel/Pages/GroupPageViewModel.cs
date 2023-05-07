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

namespace StudentsManagerApp.ViewModel.Pages
{
    public class GroupPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Group> groups;
        private ObservableCollection<Specialty> specialties;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            specialties = StudentsData.GetSpecialties();
            // Подгружаем основные данные
            Groups = StudentsData.GetGroups();
        }
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }
        public override void AddField(object? obj)
        {
            GroupDialogViewModel viewModelDialog = new GroupDialogViewModel(new Group(), StudentsData);
            viewModelDialog.LoadSpecialties();

            GroupWindow groupWindow = new GroupWindow(viewModelDialog);
            if (groupWindow.ShowDialog() == true)
            {
                Group group = viewModelDialog.Group;
                StudentsData.Add(group);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;

            GroupDialogViewModel viewModelDialog = new GroupDialogViewModel((Group)group.Clone(), StudentsData);
            viewModelDialog.LoadSpecialties();

            GroupWindow groupWindow = new GroupWindow(viewModelDialog);

            if (groupWindow.ShowDialog() == true)
            {
                group.Load(viewModelDialog.Group);
                StudentsData.Edit(group);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;

            string text = $"Вы действительно хотите удалить запись '{group.Name}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(group);
                StudentsData.SaveChanges();
            }
        }
    }
}
