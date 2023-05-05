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
    public class PhonePageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;
        private ObservableCollection<Phone> phones;
        private ObservableCollection<Person> persons;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            persons = StudentsData.GetPersons();
            // Подгружаем основные данные
            Phones = StudentsData.GetPhones();
        }
        public ObservableCollection<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged(nameof(Phones));
            }
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }


        public override void AddField(object? obj)
        {
            PhoneWindow phoneWindow = new PhoneWindow(new Phone(), StudentsData);
            if (phoneWindow.ShowDialog() == true)
            {
                Phone phone = phoneWindow.ViewModel.Phone;
                StudentsData.Add(phone);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Phone? phone = selected_obj as Phone;
            if (phone == null) return;

            string text = $"Вы действительно хотите удалить запись '{phone.Name}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(phone);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Phone? phone = selected_obj as Phone;
            if (phone == null) return;
            Phone vm = phone.Clone() as Phone;

            PhoneWindow phoneWindow = new PhoneWindow(vm, StudentsData);

            if (phoneWindow.ShowDialog() == true)
            {
                phone.Load(phoneWindow.ViewModel.Phone);
                StudentsData.Edit(phone);
                StudentsData.SaveChanges();
            }
        }

    }
}
