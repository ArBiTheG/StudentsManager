using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Phone: ICloneable, IEquatable<Phone?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string? name;
        string? description;

        public Phone()
        {
        }
        //Используется для клонирования
        private Phone(int id, int person_id, Person person, string? name, string? description)
        {
            this.id = id;
            this.person_id = person_id;
            this.person = person;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { 
            get
            {
                return id; 
            } 
        }

        /// <summary>
        /// Код человека
        /// </summary>
        public int PersonId { 
            get 
            { 
                return person_id;
            } 
            set 
            { 
                person_id = value;
            } 
        }

        /// <summary>
        /// Объект человека
        /// </summary>
        public Person Person { 
            get 
            {
                return person;
            } 
            set 
            { 
                person = value;
                OnPropertyChanged("Person");
            }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? Name { 
            get 
            {
                return name; 
            } 
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description {
            get 
            { 
                return description; 
            } 
            set
            { 
                description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Загрузить значения в поля
        /// </summary>
        /// <param name="phone">Откуда будут взяты значения полей</param>
        public void Load(Phone phone)
        {
            PersonId = phone.person_id;
            Person = phone.person;
            Name = phone.name;
            Description = phone.description;
        }
        public object Clone() => new Phone(id, person_id, person, name, description);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Phone);
        }

        public bool Equals(Phone? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   name == other.name &&
                   description == other.description;
        }

        public static bool operator ==(Phone? left, Phone? right)
        {
            return EqualityComparer<Phone>.Default.Equals(left, right);
        }

        public static bool operator !=(Phone? left, Phone? right)
        {
            return !(left == right);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
