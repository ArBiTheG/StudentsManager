using System;

namespace StudentsManagerData.Table
{
    public class Person
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

    }
}
