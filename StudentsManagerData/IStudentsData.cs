using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public interface IStudentsData : IDisposable
    {
        /// <summary>
        /// Получить коллекцию электронных почт из базы данных
        /// </summary>
        public ObservableCollection<Email> GetEmails();
        /// <summary>
        /// Получить коллекцию учебных групп из базы данных
        /// </summary>
        public ObservableCollection<Group> GetGroups();
        /// <summary>
        /// Получить коллекцию увлечений из базы данных
        /// </summary>
        public ObservableCollection<Hobby> GetHobbies();
        /// <summary>
        /// Получить коллекцию персональные данные из базы данных
        /// </summary>
        public ObservableCollection<Person> GetPersons();
        /// <summary>
        /// Получить коллекцию номеров телефонов из базы данных
        /// </summary>
        public ObservableCollection<Phone> GetPhones();
        /// <summary>
        /// Получить коллекцию отношений из базы данных
        /// </summary>
        public ObservableCollection<Relation> GetRelations();
        /// <summary>
        /// Получить коллекцию учебных заведений из базы данных
        /// </summary>
        public ObservableCollection<School> GetSchools();
        /// <summary>
        /// Получить коллекцию специальностей из базы данных
        /// </summary>
        public ObservableCollection<Specialty> GetSpecialties();
        /// <summary>
        /// Получить коллекцию студентов из базы данных
        /// </summary>
        public ObservableCollection<Student> GetStudents();

        /// <summary>
        /// Добавить сущность в контекст данных
        /// </summary>
        /// <typeparam name="Entity">Тип объекта сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        public void Add<Entity>(Entity entity);
        /// <summary>
        /// Удалить сущность из контекста данных
        /// </summary>
        /// <typeparam name="Entity">Тип объекта сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        public void Remove<Entity>(Entity entity);
        /// <summary>
        /// Применить статус "Изменено" для сущности в контексте данных
        /// </summary>
        /// <typeparam name="Entity">Тип объекта сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        public void Edit<Entity>(Entity entity);
        /// <summary>
        /// Внести изменения из контекста данных в базу данных
        /// </summary>
        /// <return>Количество записей состояния, записанных в базу данных</return>
        public int SaveChanges();
    }
}
