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
            DiplomaWindow diplomaWindow = new DiplomaWindow(new Diploma(), StudentsData);
            if (diplomaWindow.ShowDialog() == true)
            {
                Diploma diploma = diplomaWindow.ViewModel.Diploma;
                StudentsData.Add(diploma);
                StudentsData.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            StudentsData.Remove(diploma);
            StudentsData.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            Diploma vm = diploma.Clone() as Diploma;

            DiplomaWindow diplomaWindow = new DiplomaWindow(vm, StudentsData);

            if (diplomaWindow.ShowDialog() == true)
            {
                diploma.Load(diplomaWindow.ViewModel.Diploma);
                StudentsData.Edit(diploma);
                StudentsData.SaveChanges();
            }
        }
    }
}
