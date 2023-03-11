using Microsoft.EntityFrameworkCore;
using StudentsManagerApp.View.DialogWindows;
using StudentsManagerData;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerApp.ViewModel.Pages
{
    public class PersonPageModel : BasePageModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public PersonPageModel(StudentsContext studentsContext)
        {
            StudentsContext = studentsContext;
            StudentsContext.Persons.Load();
            Persons = StudentsContext.Persons.Local.ToObservableCollection();
        }
        public override void AddField(object? obj)
        {
            PersonWindow personWindow = new PersonWindow(new Person());
            if (personWindow.ShowDialog() == true)
            {
                Person person = personWindow.Person;
                StudentsContext.Persons.Add(person);
                StudentsContext.SaveChanges();
            }
        }

        public override void DeleteField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            StudentsContext.Persons.Remove(person);
            StudentsContext.SaveChanges();
        }

        public override void EditField(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            Person vm = person.Clone() as Person;

            PersonWindow personWindow = new PersonWindow(vm);

            if (personWindow.ShowDialog() == true)
            {
                person.Write(personWindow.Person);
                StudentsContext.Entry(person).State = EntityState.Modified;
                StudentsContext.SaveChanges();
            }
        }
    }
}
