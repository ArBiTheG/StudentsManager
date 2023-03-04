using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Hobby: ICloneable, IEquatable<Hobby?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string? name;
        string? description;

        public Hobby()
        {
        }
        //Используется для клонирования
        private Hobby(int id, int person_id, Person person, string? name, string? description)
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
            private set
            { 
                person = value;
                OnPropertyChanged("Person");
            } 
        }

        /// <summary>
        /// Наименование хобби
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
        /// Записать новые значения в поля
        /// </summary>
        /// <param name="hobby">Откуда будут взяты значения полей</param>
        public void Write(Hobby hobby)
        {
            PersonId = hobby.person_id;
            Person = hobby.person;
            Name = hobby.name;
            Description = hobby.description;
        }
        public object Clone() => new Hobby(id,person_id,person,name,description);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Hobby);
        }

        public bool Equals(Hobby? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   name == other.name &&
                   description == other.description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, person_id, person, name, description);
        }

        public static bool operator ==(Hobby? left, Hobby? right)
        {
            return EqualityComparer<Hobby>.Default.Equals(left, right);
        }

        public static bool operator !=(Hobby? left, Hobby? right)
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
