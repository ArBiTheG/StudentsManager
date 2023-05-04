using Microsoft.EntityFrameworkCore;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public class StudentsData : IStudentsData
    {
        private StudentsContext _studentsContext;

        public StudentsData()
        {
            _studentsContext = new StudentsContext();
#if DEBUG
            Trace.WriteLine($"Инициализирован: {this} / hash: {this.GetHashCode()}");
#endif
        }

        public ObservableCollection<Diploma> GetDiplomas()
        {
            _studentsContext.Diplomas.Load();
            return _studentsContext.Diplomas.Local.ToObservableCollection();
        }

        public ObservableCollection<Email> GetEmails()
        {
            _studentsContext.Emails.Load();
            return _studentsContext.Emails.Local.ToObservableCollection();
        }

        public ObservableCollection<Group> GetGroups()
        {
            _studentsContext.Groups.Load();
            return _studentsContext.Groups.Local.ToObservableCollection();
        }

        public ObservableCollection<Hobby> GetHobbies()
        {
            _studentsContext.Hobbies.Load();
            return _studentsContext.Hobbies.Local.ToObservableCollection();
        }

        public ObservableCollection<Person> GetPersons()
        {
            _studentsContext.Persons.Load();
            return _studentsContext.Persons.Local.ToObservableCollection();
        }

        public ObservableCollection<Phone> GetPhones()
        {
            _studentsContext.Phones.Load();
            return _studentsContext.Phones.Local.ToObservableCollection();
        }

        public ObservableCollection<Relation> GetRelations()
        {
            _studentsContext.Relations.Load();
            return _studentsContext.Relations.Local.ToObservableCollection();
        }

        public ObservableCollection<School> GetSchools()
        {
            _studentsContext.Schools.Load();
            return _studentsContext.Schools.Local.ToObservableCollection();
        }

        public ObservableCollection<Specialty> GetSpecialties()
        {
            _studentsContext.Specialties.Load();
            return _studentsContext.Specialties.Local.ToObservableCollection();
        }

        public ObservableCollection<Student> GetStudents()
        {
            _studentsContext.Students.Load();
            return _studentsContext.Students.Local.ToObservableCollection();
        }

        public void Add<Entity>(Entity entity)
        {
            _studentsContext.Add(entity);
        }

        public void Edit<Entity>(Entity entity)
        {
            _studentsContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove<Entity>(Entity entity)
        {
            _studentsContext.Remove(entity);
        }

        public int SaveChanges()
        {
            return _studentsContext.SaveChanges();
        }

        public void Dispose()
        {
            _studentsContext.Dispose();
        }
    }
}
