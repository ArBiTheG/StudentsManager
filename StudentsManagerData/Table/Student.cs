using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Student
    {
        int id;
        int person_id;
        Person person;
        int group_id;
        Group group;
        DateTime date_entry;
        DateTime date_escape;
        bool is_escaped;
        string? reason;

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
        /// Код группы
        /// </summary>
        public int GroupId { get { return group_id; } set { group_id = value; } }

        /// <summary>
        /// Объект группы
        /// </summary>
        public Group Group { get { return group; } private set { group = value; } }
        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime DateEntry { get { return date_entry; } set { date_entry = value; } }
        /// <summary>
        /// Дата отчисления
        /// </summary>
        public DateTime DateEscape { get { return date_escape; } set { date_escape = value; } }
        /// <summary>
        /// Отчислен?
        /// </summary>
        public bool IsEscaped { get { return is_escaped; } set { is_escaped = value; } }
        /// <summary>
        /// Причина отчисления
        /// </summary>
        public string? Reason { get { return reason; } set { reason = value; } }
    }
}
