using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Snils : IPerson, ICopyable<Snils?>, ICloneable<Snils?>, IEquatable<Snils?>, INotifyPropertyChanged
    {
        private int id;
        private int person_id;
        private Person person;
        private string name;

        public Snils()
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
        /// Снилс
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

        [NotMapped]
        public string FirstName
        {
            get
            {
                if (person == null)
                    return string.Empty;
                return Person.FirstName;
            }
            set
            {
                if (person == null)
                {
#if DEBUG
                    Trace.WriteLine($"Class '{this}': Отсутствует объект к которому присваивается свойство {nameof(FirstName)}");
#endif
                    return;
                }
                Person.FirstName = value;
            }
        }

        [NotMapped]
        public string MiddleName
        {
            get
            {
                if (person == null)
                    return string.Empty;
                return Person.MiddleName;
            }
            set
            {
                if (person == null)
                {
#if DEBUG
                    Trace.WriteLine($"Class '{this}': Отсутствует объект к которому присваивается свойство {nameof(MiddleName)}");
#endif
                    return;
                }
                Person.MiddleName = value;
            }
        }

        [NotMapped]
        public string LastName
        {
            get
            {
                if (person == null)
                    return string.Empty;
                return Person.LastName;
            }
            set
            {
                if (person == null)
                {
#if DEBUG
                    Trace.WriteLine($"Class '{this}': Отсутствует объект к которому присваивается свойство {nameof(LastName)}");
#endif
                    return;
                }
                Person.LastName = value;
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (person == null)
                    return string.Empty;
                return Person.FullName;
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Snils);
        }

        public Snils? Clone()
        {
            return new Snils()
            {
                id = id,
                person_id = person_id,
                name = name,
                person = person,
            };
        }

        public void Copy(Snils? entity)
        {
            if (entity == null) return;
            PersonId = entity.person_id;
            Person = entity.person;
            Name = entity.name;
        }

        public bool Equals(Snils? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   name == other.name;
        }

        public static bool operator ==(Snils? left, Snils? right)
        {
            return EqualityComparer<Snils>.Default.Equals(left, right);
        }

        public static bool operator !=(Snils? left, Snils? right)
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
