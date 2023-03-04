using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Specialy: ICloneable, IEquatable<Specialy?>
    {
        int id;
        string? code;
        string? name;
        string? skill;
        int duration;
        string? description;
        DateTime date_created;
        DateTime date_deleted;
        bool is_deleted;
        string? reason;

        //Используется для клонирования
        private Specialy(int id, string? code, string? name, string? skill, int duration, string? description, DateTime date_created, DateTime date_deleted, bool is_deleted, string? reason)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.skill = skill;
            this.duration = duration;
            this.description = description;
            this.date_created = date_created;
            this.date_deleted = date_deleted;
            this.is_deleted = is_deleted;
            this.reason = reason;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Шифр специальности
        /// </summary>
        public string Code { get { return code; } set { code = value; } }

        /// <summary>
        /// Наименование специальности
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Квалификация выпускника
        /// </summary>
        public string Skill { get { return skill; } set { skill = value; } }

        /// <summary>
        /// Длительность обучения
        /// </summary>
        /// <remarks>
        /// Указывается в месяцах
        /// </remarks>
        public int Duration { get { return duration; } set { duration = value; } }
        /// <summary>
        /// Описание специальности
        /// </summary>
        public string? Description { get { return description; } set { description = value; } }
        /// <summary>
        /// Дата начала набора на специальность
        /// </summary>
        public DateTime DateCreated { get { return date_created; } set { date_created = value; } }
        /// <summary>
        /// Дата прекращения набора на специальность
        /// </summary>
        public DateTime ВateDeleted { get { return date_deleted; } set { date_deleted = value; } }
        /// <summary>
        /// Набор прекращён?
        /// </summary>
        public bool IsDeleted { get { return is_deleted; } set { is_deleted = value; } }
        /// <summary>
        /// Причина прекращения набора на специальность
        /// </summary>
        public string? Reason { get { return reason; } set { reason = value; } }

        public object Clone() => new Specialy(id,code,name,skill,duration,description,date_created,date_deleted, is_deleted,reason);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Specialy);
        }

        public bool Equals(Specialy? other)
        {
            return other is not null &&
                   id == other.id &&
                   code == other.code &&
                   name == other.name &&
                   skill == other.skill &&
                   duration == other.duration &&
                   description == other.description &&
                   date_created == other.date_created &&
                   date_deleted == other.date_deleted &&
                   is_deleted == other.is_deleted &&
                   reason == other.reason;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(id);
            hash.Add(code);
            hash.Add(name);
            hash.Add(skill);
            hash.Add(duration);
            hash.Add(description);
            hash.Add(date_created);
            hash.Add(date_deleted);
            hash.Add(is_deleted);
            hash.Add(reason);
            return hash.ToHashCode();
        }

        public static bool operator ==(Specialy? left, Specialy? right)
        {
            return EqualityComparer<Specialy>.Default.Equals(left, right);
        }

        public static bool operator !=(Specialy? left, Specialy? right)
        {
            return !(left == right);
        }
    }
}
