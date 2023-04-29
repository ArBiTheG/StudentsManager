using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Diploma : ICloneable, IEquatable<Diploma?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string? series;
        string? number;
        DateTime given;
        int school_id;
        School school;
        string? name;

        public Diploma()
        {
        }

        //Используется для клонирования
        private Diploma(int id, int person_id, Person person, string? series, string? number, DateTime given, int school_id, School school, string? name)
        {
            this.id = id;
            this.person_id = person_id;
            this.person = person;
            this.series = series;
            this.number = number;
            this.given = given;
            this.school_id = school_id;
            this.school = school;
            this.name = name;
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
                OnPropertyChanged("Person");
            }
        }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string? Series
        {
            get
            {
                return series;
            }
            set
            {
                series = value;
                OnPropertyChanged("Series");
            }
        }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string? Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime Given
        {
            get
            {
                return given;
            }
            set
            {
                given = value;
                OnPropertyChanged("Given");
            }
        }

        /// <summary>
        /// Код школы
        /// </summary>
        public int SchoolId
        {
            get
            {
                return school_id;
            }
            set
            {
                school_id = value;
            }
        }

        /// <summary>
        /// Объект школы
        /// </summary>
        public School School
        {
            get
            {
                return school;
            }
            set
            {
                school = value;
                OnPropertyChanged("School");
            }
        }

        /// <summary>
        /// Наименование документа
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
        /// Загрузить значения в поля
        /// </summary>
        /// <param name="diploma">Откуда будут взяты значения полей</param>
        public void Load(Diploma diploma)
        {
            PersonId = diploma.person_id;
            Person = diploma.person;
            Series = diploma.series;
            Number = diploma.number;
            Given = diploma.given;
            SchoolId = diploma.school_id;
            School = diploma.school;
            Name = diploma.name;
        }
        public object Clone() => new Diploma(id, person_id, person, series, number, given, school_id, school, name);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Diploma);
        }

        public bool Equals(Diploma? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   series == other.series &&
                   number == other.number &&
                   given == other.given &&
                   school_id == other.school_id &&
                   EqualityComparer<School>.Default.Equals(school, other.school) &&
                   name == other.name;
        }

        public static bool operator ==(Diploma? left, Diploma? right)
        {
            return EqualityComparer<Diploma>.Default.Equals(left, right);
        }

        public static bool operator !=(Diploma? left, Diploma? right)
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
