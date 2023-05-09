using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Diploma : ICopyable<Diploma?>, ICloneable<Diploma?>, IEquatable<Diploma?>, INotifyPropertyChanged
    {
        int id;
        int person_id;
        Person person;
        string series;
        string number;
        DateTime? date_given;
        int school_id;
        School school;
        string? skill;
        int? type_diploma;

        public Diploma()
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
        /// Серия документа
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
        /// Номер документа
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
        /// Дата выдачи документа
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

        /// <summary>
        /// Код учебного заведения
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
        /// Объект учебного заведения
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
                OnPropertyChanged(nameof(School));
            }
        }

        /// <summary>
        /// Полученная квалификация
        /// </summary>
        public string? Skill
        {
            get
            {
                return skill;
            }
            set
            {
                skill = value;
                OnPropertyChanged(nameof(Skill));
            }
        }

        /// <summary>
        /// Тип документа
        /// </summary>
        public int? TypeDiploma
        {
            get
            {
                return type_diploma;
            }
            set
            {
                type_diploma = value;
                OnPropertyChanged(nameof(TypeDiploma));
            }
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / series: " + series.ToString() + " / number: " + number.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Diploma);
        }

        public Diploma Clone() {
            return new Diploma()
            {
                id = id, 
                person_id = person_id, 
                person = person, 
                series = series, 
                number = number, 
                date_given = date_given,
                school_id = school_id, 
                school = school, 
                skill = skill, 
                type_diploma = type_diploma
            };
        }
        public void Copy(Diploma? diploma)
        {
            if (diploma == null) return;
            PersonId = diploma.person_id;
            Person = diploma.person;
            Series = diploma.series;
            Number = diploma.number;
            DateGiven = diploma.date_given;
            SchoolId = diploma.school_id;
            School = diploma.school;
            Skill = diploma.skill;
            TypeDiploma = diploma.type_diploma;
        }

        public bool Equals(Diploma? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   person == other.person &&
                   series == other.series &&
                   number == other.number &&
                   date_given == other.date_given &&
                   school_id == other.school_id &&
                   school == other.school &&
                   skill == other.skill &&
                   type_diploma == other.type_diploma;
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
