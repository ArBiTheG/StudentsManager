using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Hobby: ICopyable<Hobby?>, ICloneable<Hobby?>, IEquatable<Hobby?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string name;
        string? description;

        public Hobby()
        {
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
                OnPropertyChanged(nameof(Person));
            } 
        }
        /// <summary>
        /// Наименование хобби
        /// </summary>
        public string Name { 
            get 
            { 
                return name;
            } 
            set 
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// Описание хобби
        /// </summary>
        public string? Description { 
            get 
            { 
                return description;
            } 
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + name.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Hobby);
        }

        public void Copy(Hobby? hobby)
        {
            if (hobby == null) return;
            PersonId = hobby.person_id;
            Person = hobby.person;
            Name = hobby.name;
            Description = hobby.description;
        }
        public Hobby Clone()
        {
            return new Hobby()
            {
                id = id,
                person_id = person_id,
                person = person,
                name = name,
                description = description
            };
        }

        public bool Equals(Hobby? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   name == other.name &&
                   description == other.description;
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
