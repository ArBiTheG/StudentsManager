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
        byte gender;
        string? series_passport;
        string? number_passport;
        string? given_passport;
        DateTime? date_passport;
        string? snils;
        bool is_militaried;
        string? military_ticket;
        bool is_invalid;
        string? invalid_name;
        string? about;

        public Person()
        {
        }
        //������������ ��� ������������
        private Person(int id, string first_name, string middle_name, string last_name, DateTime birthday, byte gender, string? series_passport, string? number_passport, string? given_passport, DateTime? date_passport, string? snils, bool is_militaried, string? military_ticket, bool is_invalid, string? invalid_name, string? about)
        {
            this.id = id;
            this.first_name = first_name;
            this.middle_name = middle_name;
            this.last_name = last_name;
            this.birthday = birthday;
            this.gender = gender;
            this.series_passport = series_passport;
            this.number_passport = number_passport;
            this.given_passport = given_passport;
            this.date_passport = date_passport;
            this.snils = snils;
            this.is_militaried = is_militaried;
            this.military_ticket = military_ticket;
            this.is_invalid = is_invalid;
            this.invalid_name = invalid_name;
            this.about = about;
        }

        /// <summary>
        /// ���
        /// </summary>
        public int Id { 
            get 
            { 
                return id;
            } 
        }
        /// <summary>
        /// ���
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
        /// ��������
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
        /// �������
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
        /// ���� ��������
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
        /// ���
        /// </summary>
        public byte Gender { 
            get 
            {
                return gender; 
            } 
            set
            { 
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        /// <summary>
        /// ����� ��������
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
        /// ����� ��������
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
        /// ��� ����� �������
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
        /// ���� �������� ��������
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
        /// �����
        /// </summary>
        public string? Snils
        {
            get
            {
                return snils;
            }
            set
            {
                snils = value;
                OnPropertyChanged("Snils");
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public bool IsMilitaried
        {
            get
            {
                return is_militaried;
            }
            set
            {
                is_militaried = value;
                OnPropertyChanged("IsMilitaried");
            }
        }
        /// <summary>
        /// ������� �����
        /// </summary>
        public string? MilitaryTicket
        {
            get
            {
                return military_ticket;
            }
            set
            {
                military_ticket = value;
                OnPropertyChanged("MilitaryTicket");
            }
        }
        /// <summary>
        /// ����� ������������
        /// </summary>
        public bool IsInvalid
        {
            get
            {
                return is_invalid;
            }
            set
            {
                is_invalid = value;
                OnPropertyChanged("IsInvalid");
            }
        }
        /// <summary>
        /// �������� ������������
        /// </summary>
        public string? InvalidName
        {
            get
            {
                return invalid_name;
            }
            set
            {
                invalid_name = value;
                OnPropertyChanged("InvalidName");
            }
        }
        /// <summary>
        /// �����������
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
        /// ������ ���
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
        /// ��������
        /// </summary>
        public List<Student> Students { get; set; }
        /// <summary>
        /// ��������/�������
        /// </summary>
        public List<Diploma> Diplomas { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public List<Hobby> Hobbies { get; set; }
        /// <summary>
        /// ������ ���������
        /// </summary>
        public List<Phone> Phones { get; set; }
        /// <summary>
        /// ������ ���������� ����
        /// </summary>
        public List<Email> Emails { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public List<Relation> Childs { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        public List<Relation> Parents { get; set; }

        /// <summary>
        /// ��������� �������� � ����
        /// </summary>
        /// <param name="person">������ ����� ����� �������� �����</param>
        public void Load(Person person)
        {
            FirstName = person.first_name;
            MiddleName = person.middle_name;
            LastName = person.last_name;
            Birthday = person.birthday;
            Gender = person.gender;
            SeriesPassport = person.series_passport;
            NumberPassport = person.number_passport;
            GivenPassport = person.given_passport;
            DatePassport = person.date_passport;
            Snils = person.snils;
            IsMilitaried = person.is_militaried;
            MilitaryTicket = person.military_ticket;
            IsInvalid = person.is_invalid;
            InvalidName = person.invalid_name;
            About = person.about;
        }
        public object Clone() => new Person(id, first_name, middle_name, last_name, birthday, gender, series_passport, number_passport, given_passport, date_passport, snils, is_militaried, military_ticket, is_invalid, invalid_name, about);

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
                   gender == other.gender &&
                   series_passport == other.series_passport &&
                   number_passport == other.number_passport &&
                   given_passport == other.given_passport &&
                   date_passport == other.date_passport &&
                   snils == other.snils &&
                   is_militaried == other.is_militaried &&
                   military_ticket == other.military_ticket &&
                   is_invalid == other.is_invalid &&
                   invalid_name == other.invalid_name &&
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
