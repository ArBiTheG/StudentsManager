using System;
using System.Collections.Generic;

namespace StudentsManagerData.Table
{
    public class Person: ICloneable, IEquatable<Person?>
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
        DateTime date_passport;
        string? about;

        //Используется для клонирования
        private Person(int id, string first_name, string middle_name, string last_name, DateTime birthday, byte sex, string? series_passport, string? number_passport, string? given_passport, DateTime date_passport, string? about)
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
        public int Id { get { return id; } }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return first_name; } set { first_name = value; } }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get { return middle_name; } set { middle_name = value; } }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return last_name; } set { last_name = value; } }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        /// <summary>
        /// Пол
        /// </summary>
        public byte Sex { get { return sex; } set { sex = value; } }
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string? SeriesPassport { get { return series_passport; } set { series_passport = value; } }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string? NumberPassport { get { return number_passport; } set { number_passport = value; } }
        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string? GivenPassword { get { return given_passport; } set { given_passport = value; } }
        /// <summary>
        /// Дата вручения паспорта
        /// </summary>
        public DateTime DatePassport { get { return date_passport; } set { date_passport = value; } }
        /// <summary>
        /// Подробности
        /// </summary>
        public string? About { get { return about; } set { about = value; } }

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
    }
}
