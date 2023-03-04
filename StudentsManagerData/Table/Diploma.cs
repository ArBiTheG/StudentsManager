using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class Diploma
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

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Код человека
        /// </summary>
        public int PersonId { get { return person_id; } set { person_id = value; } }

        /// <summary>
        /// Объект человека
        /// </summary>
        public Person Person { get { return person; } private set { person = value; } }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string? Series { get { return series; } set { series = value; } }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string? Number { get { return number; } set { number = value; } }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime Given { get { return given; } set { given = value; } }

        /// <summary>
        /// Код школы
        /// </summary>
        public int SchoolId { get { return school_id; } set { school_id = value; } }

        /// <summary>
        /// Объект школы
        /// </summary>
        public School School { get { return school; } private set { school = value; } }

        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get { return name; } private set { name = value; } }
    }
}
