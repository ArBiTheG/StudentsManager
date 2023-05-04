using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Person: ICloneable, IEquatable<Person?>, INotifyPropertyChanged
    {
        int id;
        string first_name;
        string middle_name;
        string last_name;
        DateTime birthday;
        byte sex;
        string? series_passport;
        string? number_passport;
        string? given_passport;
        DateTime? date_passport;
        string? about;

        public Person()
        {
        }
        //Используется для клонирования
        private Person(int id, string first_name, string middle_name, string last_name, DateTime birthday, byte sex, string? series_passport, string? number_passport, string? given_passport, DateTime? date_passport, string? about)
        {
            this.id = id;
            this.first_name = first_name;
            this.middle_name = middle_name;
            this.last_name = last_name;
            this.birthday = birthday;
            this.sex = sex;
            this.series_passport = series_passport;
            this.number_passport = number_passport;
            this.given_passport = given_passport;
            this.date_passport = date_passport;
            this.about = about;
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
        /// Имя
        /// </summary>
        public string FirstName {
            get
            { 
                return first_name; 
            }
            set
            {
                first_name = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { 
            get
            {
                return middle_name; 
            } 
            set
            {
                middle_name = value;
                OnPropertyChanged("MiddleName");
                OnPropertyChanged("FullName");
            } 
        }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName {
            get 
            { 
                return last_name;
            }
            set
            { 
                last_name = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday { 
            get
            { 
                return birthday;
            } 
            set
            { 
                birthday = value;
                OnPropertyChanged("Birthday");
            } 
        }
        /// <summary>
        /// Пол
        /// </summary>
        public byte Sex { 
            get 
            {
                return sex; 
            } 
            set
            { 
                sex = value;
                OnPropertyChanged("Sex");
            }
        }
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string? SeriesPassport {
            get 
            { 
                return series_passport; 
            }
            set
            { 
                series_passport = value;
                OnPropertyChanged("SeriesPassport");
            } 
        }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string? NumberPassport { 
            get 
            {
                return number_passport; 
            } 
            set 
            { 
                number_passport = value;
                OnPropertyChanged("NumberPassport");
            }
        }
        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string? GivenPassport
        { 
            get 
            { 
                return given_passport; 
            } 
            set 
            { 
                given_passport = value;
                OnPropertyChanged("GivenPassport");
            } 
        }
        /// <summary>
        /// Дата вручения паспорта
        /// </summary>
        public DateTime? DatePassport { 
            get 
            { 
                return date_passport; 
            } 
            set 
            { 
                date_passport = value;
                OnPropertyChanged("DatePassport");
            } 
        }
        /// <summary>
        /// Подробности
        /// </summary>
        public string? About { 
            get 
            { 
                return about; 
            } 
            set 
            { 
                about = value;
                OnPropertyChanged("About");
            }
        }
        /// <summary>
        /// Полное имя
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{last_name} {first_name} {middle_name}";
            }
        }

        /// <summary>
        /// Студенты
        /// </summary>
        public List<Student> Students { get; set; }
        /// <summary>
        /// Атестаты/Дипломы
        /// </summary>
        public List<Diploma> Diplomas { get; set; }
        /// <summary>
        /// Хобби
        /// </summary>
        public List<Hobby> Hobbies { get; set; }
        /// <summary>
        /// Номера телефонов
        /// </summary>
        public List<Phone> Phones { get; set; }
        /// <summary>
        /// Адреса элетронных почт
        /// </summary>
        public List<Email> Emails { get; set; }
        /// <summary>
        /// Детей
        /// </summary>
        public List<Relation> Childs { get; set; }
        /// <summary>
        /// Родителей
        /// </summary>
        public List<Relation> Parents { get; set; }

        /// <summary>
        /// Загрузить значения в поля
        /// </summary>
        /// <param name="person">Откуда будут взяты значения полей</param>
        public void Load(Person person)
        {
            FirstName = person.first_name;
            MiddleName = person.middle_name;
            LastName = person.last_name;
            Birthday = person.birthday;
            Sex = person.sex;
            SeriesPassport = person.series_passport;
            NumberPassport = person.number_passport;
            GivenPassport = person.given_passport;
            DatePassport = person.date_passport;
            About = person.about;
        }
        public object Clone() => new Person(id, first_name, middle_name, last_name, birthday, sex, series_passport, number_passport, given_passport, date_passport, about);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   id == other.id &&
                   first_name == other.first_name &&
                   middle_name == other.middle_name &&
                   last_name == other.last_name &&
                   birthday == other.birthday &&
                   sex == other.sex &&
                   series_passport == other.series_passport &&
                   number_passport == other.number_passport &&
                   given_passport == other.given_passport &&
                   date_passport == other.date_passport &&
                   about == other.about;
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }

        public new string ToString()
        {
            return "id: " + id.ToString() + " / name: " + FullName.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
