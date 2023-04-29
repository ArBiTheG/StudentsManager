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
    public class DiplomaPageViewModel : BasePageViewModel<Diploma>
    {
        private ObservableCollection<Person> persons;
        private ObservableCollection<School> schools;
        public override void Load()
        {
            StudentsContext = new StudentsContext();
            StudentsContext.Diplomas.Load();
            StudentsContext.Persons.Load();
            StudentsContext.Schools.Load();
            PrimaryList = StudentsContext.Diplomas.Local.ToObservableCollection();
            persons = StudentsContext.Persons.Local.ToObservableCollection();
            schools = StudentsContext.Schools.Local.ToObservableCollection();

        }
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void AddField(object? obj)
        {
            DiplomaWindow diplomaWindow = new DiplomaWindow(new Diploma(), persons, schools);
            if (diplomaWindow.ShowDialog() == true)
            {
                Diploma diploma = diplomaWindow.ViewModel.Diploma;
                StudentsContext.Diplomas.Add(diploma);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            StudentsContext.Diplomas.Remove(diploma);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Diploma? diploma = selected_obj as Diploma;
            if (diploma == null) return;
            Diploma vm = diploma.Clone() as Diploma;

            DiplomaWindow diplomaWindow = new DiplomaWindow(vm, persons, schools);

            if (diplomaWindow.ShowDialog() == true)
            {
                diploma.Load(diplomaWindow.ViewModel.Diploma);
                StudentsContext.Diplomas.Entry(diploma).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
