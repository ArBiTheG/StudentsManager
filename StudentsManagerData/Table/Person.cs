using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        //???????????? ??? ????????????
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
        /// ???
        /// </summary>
        public int Id { 
            get 
            { 
                return id;
            } 
        }
        /// <summary>
        /// ???
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
            }
        }
        /// <summary>
        /// ????????
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
            } 
        }
        /// <summary>
        /// ???????
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
            }
        }
        /// <summary>
        /// ???? ????????
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
        /// ???
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
        /// ????? ????????
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
        /// ????? ????????
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
        /// ??? ????? ???????
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
        /// ???? ???????? ????????
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
        /// ???????????
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
        /// ????????
        /// </summary>
        public List<Student> Students { get; set; }
        /// <summary>
        /// ????????/???????
        /// </summary>
        public List<Diploma> Diplomas { get; set; }
        /// <summary>
        /// ?????
        /// </summary>
        public List<Hobby> Hobbies { get; set; }
        /// <summary>
        /// ?????? ?????????
        /// </summary>
        public List<Phone> Phones { get; set; }
        /// <summary>
        /// ?????? ?????????? ????
        /// </summary>
        public List<Email> Emails { get; set; }
        /// <summary>
        /// ?????
        /// </summary>
        public List<Relation> Childs { get; set; }
        /// <summary>
        /// ?????????
        /// </summary>
        public List<Relation> Parents { get; set; }

        /// <summary>
        /// ???????? ????? ???????? ? ????
        /// </summary>
        /// <param name="person">?????? ????? ????? ???????? ?????</param>
        public void Write(Person person)
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

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(id);
            hash.Add(first_name);
            hash.Add(middle_name);
            hash.Add(last_name);
            hash.Add(birthday);
            hash.Add(sex);
            hash.Add(series_passport);
            hash.Add(number_passport);
            hash.Add(given_passport);
            hash.Add(date_passport);
            hash.Add(about);
            return hash.ToHashCode();
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
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
