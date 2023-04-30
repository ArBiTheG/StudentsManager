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
            GroupWindow groupWindow = new GroupWindow(new Group(), StudentsData);
            if (groupWindow.ShowDialog() == true)
            {
                Group group = groupWindow.ViewModel.Group;
                StudentsData.Add(group);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;
            StudentsData.Remove(group);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Group? group = selected_obj as Group;
            if (group == null) return;
            Group vm = group.Clone() as Group;

            GroupWindow groupWindow = new GroupWindow(vm, StudentsData);

            if (groupWindow.ShowDialog() == true)
            {
                group.Load(groupWindow.ViewModel.Group);
                StudentsData.Edit(group);
                StudentsData.SaveChanges();
            }
        }

    }
}
