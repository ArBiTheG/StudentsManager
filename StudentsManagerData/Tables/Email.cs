using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Tables
{
    public class Email: ICopyable<Email?>, ICloneable<Email?>, IEquatable<Email?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string name;
        string? description;

        public Email()
        {
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
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
            }
        }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Name
        {
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
                OnPropertyChanged(nameof(Description));
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + name.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Email);
        }

        public Email Clone()
        {
            return new Email()
            {
                id = id,
                person_id = person_id,
                person = person,
                name = name,
                description = description
            };
        }

        public void Copy(Email? email)
        {
            if (email == null) return;
            email.PersonId = person_id;
            email.Person = person;
            email.Name = name;
            email.Description = description;
        }

        public bool Equals(Email? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
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
