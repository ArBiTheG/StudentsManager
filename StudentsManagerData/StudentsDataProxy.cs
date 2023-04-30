using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StudentsManagerData
{
    public class StudentsDataProxy: IStudentsData
    {
        private StudentsContext _studentsContext;
        private ObservableCollection<Diploma> _diplomas;
        private ObservableCollection<Email> _emails;
        private ObservableCollection<Group> _groups;
        private ObservableCollection<Hobby> _hobbies;
        private ObservableCollection<Person> _persons;
        private ObservableCollection<Phone> _phones;
        private ObservableCollection<Relation> _relations;
        private ObservableCollection<School> _schools;
        private ObservableCollection<Specialty> _specialties;
        private ObservableCollection<Student> _students;

        public StudentsDataProxy()
        {
            _studentsContext = new StudentsContext();
        }

        public ObservableCollection<Diploma> GetDiplomas()
        {
            if (_diplomas==null)
                _diplomas = _studentsContext.GetDiplomas();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Diplomas)}' hash: {_diplomas.GetHashCode()}");
#endif
            return _diplomas;
        }

        public ObservableCollection<Email> GetEmails()
        {
            if (_emails == null)
                _emails = _studentsContext.GetEmails();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Emails)}' hash: {_emails.GetHashCode()}");
#endif
            return _emails;
        }

        public ObservableCollection<Group> GetGroups()
        {
            if (_groups == null)
                _groups = _studentsContext.GetGroups();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Groups)}' hash: {_groups.GetHashCode()}");
#endif
            return _groups;
        }

        public ObservableCollection<Hobby> GetHobbies()
        {
            if (_hobbies == null)
                _hobbies = _studentsContext.GetHobbies();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Hobbies)}' hash: {_hobbies.GetHashCode()}");
#endif
            return _hobbies;
        }

        public ObservableCollection<Person> GetPersons()
        {
            if (_persons == null)
                _persons = _studentsContext.GetPersons();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Persons)}' hash: {_persons.GetHashCode()}");
#endif
            return _persons;
        }

        public ObservableCollection<Phone> GetPhones()
        {
            if (_phones == null)
                _phones = _studentsContext.GetPhones();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Phones)}' hash: {_phones.GetHashCode()}");
#endif
            return _phones;
        }

        public ObservableCollection<Relation> GetRelations()
        {
            if (_relations == null)
                _relations = _studentsContext.GetRelations();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Relations)}' hash: {_relations.GetHashCode()}");
#endif
            return _relations;
        }

        public ObservableCollection<School> GetSchools()
        {
            if (_schools == null)
                _schools = _studentsContext.GetSchools();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Schools)}' hash: {_schools.GetHashCode()}");
#endif
            return _schools;
        }

        public ObservableCollection<Specialty> GetSpecialties()
        {
            if (_specialties == null)
                _specialties = _studentsContext.GetSpecialties();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Specialties)}' hash: {_specialties.GetHashCode()}");
#endif
            return _specialties;
        }

        public ObservableCollection<Student> GetStudents()
        {
            if (_students == null)
                _students = _studentsContext.GetStudents();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(_studentsContext.Students)}' hash: {_students.GetHashCode()}");
#endif
            return _students;
        }

        public void Remove<Entity>(Entity entity)
        {
            _studentsContext.Remove(entity);
        }

        public void Add<Entity>(Entity entity)
        {
            _studentsContext.Add(entity);
        }

        public void Edit<Entity>(Entity entity)
        {
            _studentsContext.Edit(entity);
        }
        public int SaveChanges()
        {
            return _studentsContext.SaveChanges();
        }
    }
}
