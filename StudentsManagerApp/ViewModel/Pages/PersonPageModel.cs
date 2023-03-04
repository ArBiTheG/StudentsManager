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
    public class PersonPageModel : BaseHandleModel
    {
        StudentsContext studentsContext;
        public ObservableCollection<Person> Persons { get; set; }
        public PersonPageModel(StudentsContext studentsContext)
        {
            this.studentsContext = studentsContext;
            this.studentsContext.Persons.Load();
            Persons = this.studentsContext.Persons.Local.ToObservableCollection();
        }
        public override void Add(object? obj)
        {
            PersonWindow personWindow = new PersonWindow(new Person());
            if (personWindow.ShowDialog() == true)
            {
                Person person = personWindow.Person;
                studentsContext.Persons.Add(person);
                studentsContext.SaveChanges();
            }
        }

        public override void Delete(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            studentsContext.Persons.Remove(person);
            studentsContext.SaveChanges();
        }

        public override void Edit(object? selected_obj)
        {
            Person? person = selected_obj as Person;
            if (person == null) return;
            Person vm = person.Clone() as Person;

            PersonWindow personWindow = new PersonWindow(vm);

            if (personWindow.ShowDialog() == true)
            {
                person.Write(personWindow.Person);
                studentsContext.Entry(person).State = EntityState.Modified;
                studentsContext.SaveChanges();
            }
        }
    }
}
