using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Student: ICloneable, IEquatable<Student?>
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

        //Используется для клонирования
        private Student(int id, int person_id, Person person, int group_id, Group group, DateTime date_entry, DateTime date_escape, bool is_escaped, string? reason)
        {
            this.id = id;
            this.person_id = person_id;
            this.person = person;
            this.group_id = group_id;
            this.group = group;
            this.date_entry = date_entry;
            this.date_escape = date_escape;
            this.is_escaped = is_escaped;
            this.reason = reason;
        }

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

        public object Clone() => new Student(id,person_id,person,group_id,group,date_entry,date_escape,is_escaped,reason);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student? other)
        {
            return other is not null &&
                   id == other.id &&
                   person_id == other.person_id &&
                   EqualityComparer<Person>.Default.Equals(person, other.person) &&
                   group_id == other.group_id &&
                   EqualityComparer<Group>.Default.Equals(group, other.group) &&
                   date_entry == other.date_entry &&
                   date_escape == other.date_escape &&
                   is_escaped == other.is_escaped &&
                   reason == other.reason;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(id);
            hash.Add(person_id);
            hash.Add(person);
            hash.Add(group_id);
            hash.Add(group);
            hash.Add(date_entry);
            hash.Add(date_escape);
            hash.Add(is_escaped);
            hash.Add(reason);
            return hash.ToHashCode();
        }

        public static bool operator ==(Student? left, Student? right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student? left, Student? right)
        {
            return !(left == right);
        }
    }
}
