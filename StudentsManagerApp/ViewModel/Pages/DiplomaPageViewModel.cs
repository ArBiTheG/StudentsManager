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
using System.Diagnostics;
using System.Windows;
using StudentsManagerApp.ViewModel.Dialogs;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class DiplomaPageViewModel : BasePageViewModel
    {
        private IStudentsData StudentsData;

        private ObservableCollection<Diploma> diplomas;
        private ObservableCollection<Person> persons;
        private ObservableCollection<School> schools;
        public override void Load()
        {
            StudentsData = new StudentsDataProxy();
            // Подгружаем второстепенные данные
            persons = StudentsData.GetPersons();
            schools = StudentsData.GetSchools();
            // Подгружаем основные
            Diplomas = StudentsData.GetDiplomas();
        }
        public ObservableCollection<Diploma> Diplomas
        {
            get { return diplomas; }
            set
            {
                diplomas = value;
                OnPropertyChanged(nameof(Diplomas));
            }
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            DiplomaDialogViewModel viewModelDialog = new DiplomaDialogViewModel(new Diploma(), StudentsData);
            viewModelDialog.LoadPersons();
            viewModelDialog.LoadSchools();

            DiplomaWindow diplomaWindow = new DiplomaWindow(viewModelDialog);
            if (diplomaWindow.ShowDialog() == true)
            {
                Diploma diploma = viewModelDialog.Diploma;
                StudentsData.Add(diploma);
                StudentsData.SaveChanges();
            }
        }

        public override void EditField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;

            DiplomaDialogViewModel viewModelDialog = new DiplomaDialogViewModel( (Diploma)diploma.Clone() , StudentsData);
            viewModelDialog.LoadPersons();
            viewModelDialog.LoadSchools();

            DiplomaWindow diplomaWindow = new DiplomaWindow(viewModelDialog);

            if (diplomaWindow.ShowDialog() == true)
            {
                diploma.Load(viewModelDialog.Diploma);
                StudentsData.Edit(diploma);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;

            string text = $"Вы действительно хотите удалить запись '{diploma.Specialty}'?";
            var result = MessageBox.Show(text, "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                StudentsData.Remove(diploma);
                StudentsData.SaveChanges();
            }
        }
    }
}
