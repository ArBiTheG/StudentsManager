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

namespace StudentsManagerApp.ViewModel.Pages
{
    public class HobbyPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Hobby> hobbies;
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            persons = StudentsData.GetPersons();
            // Подгружаем основные данные
            Hobbies = StudentsData.GetHobbies();
        }
        public ObservableCollection<Hobby> Hobbies
        {
            get { return hobbies; }
            set
            {
                hobbies = value;
                OnPropertyChanged(nameof(Hobbies));
            }
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            HobbyWindow hobbyWindow = new HobbyWindow(new Hobby(), StudentsData);
            if (hobbyWindow.ShowDialog() == true)
            {
                Hobby hobby = hobbyWindow.ViewModel.Hobby;
                StudentsData.Add(hobby);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Hobby? hobby = selected_obj as Hobby;
            if (hobby == null) return;

            string text = $"Вы действительно хотите удалить запись '{hobby.Name}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(hobby);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Hobby? hobby = selected_obj as Hobby;
            if (hobby == null) return;
            Hobby vm = hobby.Clone() as Hobby;

            HobbyWindow hobbyWindow = new HobbyWindow(vm, StudentsData);

            if (hobbyWindow.ShowDialog() == true)
            {
                hobby.Load(hobbyWindow.ViewModel.Hobby);
                StudentsData.Edit(hobby);
                StudentsData.SaveChanges();
            }
        }

    }
}
