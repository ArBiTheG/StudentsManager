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

namespace StudentsManagerData.Table
{
    public class Passport : IPerson, ICopyable<Passport?>, ICloneable<Passport?>, IEquatable<Passport?>, INotifyPropertyChanged
    {
        private int id;
        private int person_id;
        private Person person;
        private string series;
        private string number;
        private DateTime? date_given;
        private string given;

        public Passport()
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
        /// Серия паспорта
        /// </summary>
        public string Series
        {
            get
            {
                return series;
            }
            set
            {
                series = value;
                OnPropertyChanged(nameof(Series));
            }
        }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string Given
        {
            get
            {
                return given;
            }
            set
            {
                given = value;
                OnPropertyChanged(nameof(Given));
            }
        }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime? DateGiven
        {
            get
            {
                return date_given;
            }
            set
            {
                date_given = value;
                OnPropertyChanged(nameof(DateGiven));
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
            return Equals(obj as Passport);
        }

        public static bool operator ==(Passport? left, Passport? right)
        {
            return EqualityComparer<Passport>.Default.Equals(left, right);
        }

        public static bool operator !=(Passport? left, Passport? right)
        {
            return !(left == right);
        }

        public Passport? Clone()
        {
            return new Passport()
            {
                id = id,
                person_id = person_id,
                person = person,
                series = series,
                number = number,
                given = given,
                date_given = date_given,
            };
        }

        public void Copy(Passport? entity)
        {
            if (entity == null) return;
            PersonId = entity.person_id;
            Person = entity.person;
            Series = entity.series;
            Number = entity.number;
            Given = entity.given;
            DateGiven = entity.date_given;
        }

        public bool Equals(Passport? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   series == other.series &&
                   number == other.number &&
                   given == other.given &&
                   date_given == other.date_given;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
