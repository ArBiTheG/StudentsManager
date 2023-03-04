using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Phone
    {
        int id;
        int person_id;
        Person person;
        string? name;
        string? description;


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
        /// Номер телефона
        /// </summary>
        public string? Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get { return description; } set { description = value; } }
    }
}
