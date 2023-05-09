using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Person: IPerson,ICopyable<Person?>, ICloneable<Person?>, IEquatable<Person?>, INotifyPropertyChanged
    {
        int id;
        string first_name;
        string middle_name;
        string last_name;
        DateTime birthday;
        byte gender;
        string? about;

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
                OnPropertyChanged(nameof(Birthday));
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
        /// Объект студента
        /// </summary>
        public Student? Student { get; set; }

        /// <summary>
        /// Объект куратора
        /// </summary>
        public Curator? Curator { get; set; }

        /// <summary>
        /// Объект ИНН
        /// </summary>
        public INN? INN { get; set; }

        /// <summary>
        /// Объект Паспорта
        /// </summary>
        public Passport? Passport { get; set; }

        /// <summary>
        /// Объект Снилса
        /// </summary>
        public Snils? Snils { get; set; }

        /// <summary>
        /// Объект инвалидности
        /// </summary>
        public Invalid? Invalid { get; set; }

        /// <summary>
        /// Объект инвалидности
        /// </summary>
        public Diploma? Diploma { get; set; }

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
        public void Copy(Person? person)
        {
            if (person == null) return;
            FirstName = person.first_name;
            MiddleName = person.middle_name;
            LastName = person.last_name;
            Birthday = person.birthday;
            Gender = person.gender;
            About = person.about;
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
