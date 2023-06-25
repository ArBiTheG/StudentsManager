using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace StudentsManagerData.Tables
{
    public class Person: ICopyable<Person?>, ICloneable<Person?>, IEquatable<Person?>, INotifyPropertyChanged
    {
        int id;
        // Основная информация
        string first_name;
        string middle_name;
        string last_name;
        DateTime birthday;
        byte gender;
        string? about;
        string? birthplace;
        // Паспортные данные
        string? passport_country;
        string? passport_series;
        string? passport_number;
        string? passport_code;
        string? passport_given;
        DateTime? passport_date_given;
        // ИНН
        string? inn;
        // СНИЛС
        string? snils;
        // Образование
        string? education_document_type;
        DateTime? education_date_finish;
        string? education_series;
        string? education_number;
        int? education_school_id;
        School? education_school;

        public Person()
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
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(MiddleName));
                OnPropertyChanged(nameof(FullName));
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
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { 
            get
            {
                return birthday;
            } 
            set
            { 
                birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string? BirthPlace
        {
            get
            {
                return birthplace;
            }
            set
            {
                birthplace = value;
                OnPropertyChanged(nameof(BirthPlace));
            }
        }
        /// <summary>
        /// Пол
        /// </summary>
        public byte Gender { 
            get 
            {
                return gender; 
            } 
            set
            { 
                gender = value;
                OnPropertyChanged(nameof(Gender));
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
                OnPropertyChanged(nameof(About));
            }
        }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string? PassportCountry
        {
            get
            {
                return passport_country;
            }
            set
            {
                passport_country = value;
                OnPropertyChanged(nameof(PassportCountry));
            }
        }
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string? PassportSeries
        {
            get
            {
                return passport_series;
            }
            set
            {
                passport_series = value;
                OnPropertyChanged(nameof(PassportSeries));
            }
        }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string? PassportNumber
        {
            get
            {
                return passport_number;
            }
            set
            {
                passport_number = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }
        /// <summary>
        /// Код подразделения паспорта
        /// </summary>
        public string? PassportCode
        {
            get
            {
                return passport_code;
            }
            set
            {
                passport_code = value;
                OnPropertyChanged(nameof(PassportCode));
            }
        }
        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string? PassportGiven
        {
            get
            {
                return passport_given;
            }
            set 
            {
                passport_given = value;
                OnPropertyChanged(nameof(PassportGiven));
            }

        }
        /// <summary>
        /// Дата получения паспорта
        /// </summary>
        public DateTime? PassportDateGiven
        {
            get
            {
                return passport_date_given;
            }
            set
            {
                passport_date_given = value;
                OnPropertyChanged(nameof(PassportDateGiven));
            }
        }
        /// <summary>
        /// ИНН
        /// </summary>
        public string? INN
        {
            get
            {
                return inn;
            }
            set
            {
                inn = value;
                OnPropertyChanged(nameof(INN));
            }
        }
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? SNILS
        {
            get
            {
                return snils;
            }
            set
            {
                snils = value;
                OnPropertyChanged(nameof(SNILS));
            }
        }
        /// <summary>
        /// Тип образовательного документа 
        /// </summary>
        public string? EducationDocumentType
        {
            get
            {
                return education_document_type;
            }
            set
            {
                education_document_type = value;
                OnPropertyChanged(nameof(EducationDocumentType));
            }
        }
        /// <summary>
        /// Дата завершения учебного заведения
        /// </summary>
        public DateTime? EducationDateFinish
        {
            get
            {
                return education_date_finish;
            }
            set
            {
                education_date_finish = value;
                OnPropertyChanged(nameof(EducationDateFinish));
            }
        }
        /// <summary>
        /// Серия образовательного документа
        /// </summary>
        public string? EducationSeries
        {
            get
            {
                return education_series;
            }
            set
            {
                education_series = value;
                OnPropertyChanged(nameof(EducationSeries));
            }
        }
        /// <summary>
        /// Номер образовательного документа
        /// </summary>
        public string? EducationNumber
        {
            get
            {
                return education_number;
            }
            set
            {
                education_number = value;
                OnPropertyChanged(nameof(EducationNumber));
            }
        }
        /// <summary>
        ///Код школы
        /// </summary>
        public int? EducationSchoolId
        {
            get
            {
                return education_school_id;
            }
            set
            {
                education_school_id = value;
                OnPropertyChanged(nameof(EducationSchoolId));
            }
        }
        /// <summary>
        /// Объект школы
        /// </summary>
        public School? EducationSchool
        {
            get
            {
                return education_school;
            }
            set
            {
                education_school = value;
                OnPropertyChanged(nameof(EducationSchool));
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
        /// Объект куратора
        /// </summary>
        public Curator? Curator { get; set; }
        /// <summary>
        /// Объекты студентов
        /// </summary>
        public List<Student> Students { get; set; } = new();
        /// <summary>
        /// Список увлечений
        /// </summary>
        public List<Hobby> Hobbies { get; set; } = new();
        /// <summary>
        /// Номера телефонов
        /// </summary>
        public List<Phone> Phones { get; set; } = new();
        /// <summary>
        /// Адреса элетронных почт
        /// </summary>
        public List<Email> Emails { get; set; } = new();
        /// <summary>
        /// Детей
        /// </summary>
        public List<Relation> Childs { get; set; } = new();
        /// <summary>
        /// Родителей
        /// </summary>
        public List<Relation> Parents { get; set; } = new();

        /// <summary>
        /// Список полов
        /// </summary>
        [NotMapped]
        public static Dictionary<int, string> Genders { get; } = new Dictionary<int, string>()
        {
            { 1, "Мужской" },
            { 2, "Женский" },
        };

        public void Copy(Person? person)
        {
            if (person == null) return;
            person.FirstName = first_name;
            person.MiddleName = middle_name;
            person.LastName = last_name;
            person.Birthday = birthday;
            person.Gender = gender;
            person.About = about;
            //// TODO: Дополнить новые поля
        }
        public Person Clone()
        {
            return new Person()
            {
                id= id, 
                first_name= first_name,
                middle_name= middle_name,
                last_name= last_name, 
                birthday= birthday, 
                gender= gender,
                about= about
            };
            // TODO: Дополнить новые поля
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " / name: " + FullName.ToString();
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
