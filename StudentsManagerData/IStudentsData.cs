using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public interface IStudentsData
    {
        public ObservableCollection<Diploma> GetDiplomas();
        public ObservableCollection<Email> GetEmails();
        public ObservableCollection<Group> GetGroups();
        public ObservableCollection<Hobby> GetHobbies();
        public ObservableCollection<Person> GetPersons();
        public ObservableCollection<Phone> GetPhones();
        public ObservableCollection<Relation> GetRelations();
        public ObservableCollection<School> GetSchools();
        public ObservableCollection<Specialty> GetSpecialties();
        public ObservableCollection<Student> GetStudents();

        public void Add<Entity>(Entity entity);
        public void Remove<Entity>(Entity entity);
        public void Edit<Entity>(Entity entity);
        public int SaveChanges();
    }
}
