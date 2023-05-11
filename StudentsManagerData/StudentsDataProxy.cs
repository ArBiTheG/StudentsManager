using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace StudentsManagerData
{
    public class StudentsDataProxy: IStudentsData
    {
        private StudentsData studentsData;
        /// <summary>
        /// Коллекция кешированных сущностей Emails
        /// </summary>
        private ObservableCollection<Email> _emails;
        /// <summary>
        /// Коллекция кешированных сущностей Groups
        /// </summary>
        private ObservableCollection<Group> _groups;
        /// <summary>
        /// Коллекция кешированных сущностей Hobbies
        /// </summary>
        private ObservableCollection<Hobby> _hobbies;
        /// <summary>
        /// Коллекция кешированных сущностей Persons
        /// </summary>
        private ObservableCollection<Person> _persons;
        /// <summary>
        /// Коллекция кешированных сущностей Phones
        /// </summary>
        private ObservableCollection<Phone> _phones;
        /// <summary>
        /// Коллекция кешированных сущностей Relations
        /// </summary>
        private ObservableCollection<Relation> _relations;
        /// <summary>
        /// Коллекция кешированных сущностей Schools
        /// </summary>
        private ObservableCollection<School> _schools;
        /// <summary>
        /// Коллекция кешированных сущностей Specialties
        /// </summary>
        private ObservableCollection<Specialty> _specialties;
        /// <summary>
        /// Коллекция кешированных сущностей Students
        /// </summary>
        private ObservableCollection<Student> _students;

        public StudentsDataProxy()
        {
#if DEBUG
            Trace.WriteLine($"Инициализирован: {this} / hash: {this.GetHashCode()}");
#endif
        }

        public ObservableCollection<Email> GetEmails()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_emails == null)
                _emails = studentsData.GetEmails();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Email)}' / hash: {_emails.GetHashCode()}");
#endif
            return _emails;
        }

        public ObservableCollection<Group> GetGroups()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_groups == null)
                _groups = studentsData.GetGroups();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Group)}' / hash: {_groups.GetHashCode()}");
#endif
            return _groups;
        }

        public ObservableCollection<Hobby> GetHobbies()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_hobbies == null)
                _hobbies = studentsData.GetHobbies();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Hobby)}' / hash: {_hobbies.GetHashCode()}");
#endif
            return _hobbies;
        }

        public ObservableCollection<Person> GetPersons()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_persons == null)
                _persons = studentsData.GetPersons();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Person)}' / hash: {_persons.GetHashCode()}");
#endif
            return _persons;
        }

        public ObservableCollection<Phone> GetPhones()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_phones == null)
                _phones = studentsData.GetPhones();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Phone)}' / hash: {_phones.GetHashCode()}");
#endif
            return _phones;
        }

        public ObservableCollection<Relation> GetRelations()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_relations == null)
                _relations = studentsData.GetRelations();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Relation)}' / hash: {_relations.GetHashCode()}");
#endif
            return _relations;
        }

        public ObservableCollection<School> GetSchools()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_schools == null)
                _schools = studentsData.GetSchools();
#if DEBUG 
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(School)}' / hash: {_schools.GetHashCode()}");
#endif
            return _schools;
        }

        public ObservableCollection<Specialty> GetSpecialties()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_specialties == null)
                _specialties = studentsData.GetSpecialties();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Specialty)}' / hash: {_specialties.GetHashCode()}");
#endif
            return _specialties;
        }

        public ObservableCollection<Student> GetStudents()
        {
            if (studentsData == null)
                studentsData = new StudentsData();
            if (_students == null)
                _students = studentsData.GetStudents();
#if DEBUG
            Trace.WriteLine($"Получена коллекция объектов: '{nameof(Student)}' / hash: {_students.GetHashCode()}");
#endif
            return _students;
        }

        public void Remove<Entity>(Entity entity)
        {
            if (studentsData == null)
                return;
#if DEBUG
                Trace.WriteLine($"Удалена сущность: {entity} / {studentsData.GetHashCode()}");
#endif
            studentsData.Remove(entity);
        }

        public void Add<Entity>(Entity entity)
        {
            if (studentsData == null)
                return;
#if DEBUG
            Trace.WriteLine($"Добавлена сущность: {entity} / {studentsData.GetHashCode()}");
#endif
            studentsData.Add(entity);
        }

        public void Edit<Entity>(Entity entity)
        {
            if (studentsData == null)
                return;
#if DEBUG
            Trace.WriteLine($"Изменена сущность: {entity} / {studentsData.GetHashCode()}");
#endif
            studentsData.Edit(entity);
        }
        public int SaveChanges()
        {
            if (studentsData == null)
                return 0;
            return studentsData.SaveChanges();
        }

        public void Dispose()
        {
            studentsData.Dispose();
        }
    }
}
