using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Group: ICloneable, IEquatable<Group?>
    {
        int id;
        string name;
        int spec_id;
        Specialy specialy;
        bool is_distant;
        string? about;
        DateTime date_created;
        DateTime date_release;

        //Используется для клонирования
        private Group(int id, string name, int spec_id, Specialy specialy, bool is_distant, string? about, DateTime date_created, DateTime date_release)
        {
            this.id = id;
            this.name = name;
            this.spec_id = spec_id;
            this.specialy = specialy;
            this.is_distant = is_distant;
            this.about = about;
            this.date_created = date_created;
            this.date_release = date_release;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Код специальности
        /// </summary>
        public int SpecialyId { get { return spec_id; } set { spec_id = value; } }

        /// <summary>
        /// Объект специальности
        /// </summary>
        public Specialy Specialy { get { return specialy; } private set { specialy = value; } }
        /// <summary>
        /// Заочник?
        /// </summary>
        public bool IsDistant { get { return is_distant; } set { is_distant = value; } }
        /// <summary>
        /// Подробности
        /// </summary>
        public string? About { get { return about; } set { about = value; } }
        /// <summary>
        /// Дата создания группы
        /// </summary>
        public DateTime DateCreated { get { return date_created; } set { date_created = value; } }
        /// <summary>
        /// Дата выпуска группы
        /// </summary>
        public DateTime DateRelease { get { return date_release; } set { date_release = value; } }

        public object Clone() => new Group(id, name, spec_id, specialy, is_distant, about, date_created, date_release);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Group);
        }

        public bool Equals(Group? other)
        {
            return other is not null &&
                   id == other.id &&
                   name == other.name &&
                   spec_id == other.spec_id &&
                   EqualityComparer<Specialy>.Default.Equals(specialy, other.specialy) &&
                   is_distant == other.is_distant &&
                   about == other.about &&
                   date_created == other.date_created &&
                   date_release == other.date_release;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, name, spec_id, specialy, is_distant, about, date_created, date_release);
        }

        public static bool operator ==(Group? left, Group? right)
        {
            return EqualityComparer<Group>.Default.Equals(left, right);
        }

        public static bool operator !=(Group? left, Group? right)
        {
            return !(left == right);
        }
    }
}
