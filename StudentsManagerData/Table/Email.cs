using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Email: ICloneable, IEquatable<Email?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string? name;
        string? description;

        public Email()
        {
        }
        //Используется для клонирования
        private Email(int id, int person_id, Person person, string? name, string? description)
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
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Код человека
        /// </summary>
        public int PersonId
        {
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
        public Person Person
        {
            get
            {
                return person;
            }
            private set
            {
                person = value;
                OnPropertyChanged("Person");
            }
        }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string? Name
        {
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
        public string? Description
        {
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
        /// <param name="email">Откуда будут взяты значения полей</param>
        public void Load(Email email)
        {
            PersonId = email.person_id;
            Person = email.person;
            Name = email.name;
            Description = email.description;
        }
        public object Clone() => new Email(id,person_id,person,name,description);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Email);
        }

        public bool Equals(Email? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   name == other.name &&
                   description == other.description;
        }

        public static bool operator ==(Email? left, Email? right)
        {
            return EqualityComparer<Email>.Default.Equals(left, right);
        }

        public static bool operator !=(Email? left, Email? right)
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
