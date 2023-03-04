using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Relation:ICloneable, IEquatable<Relation?>
    {
        int id;
        int parent_id;
        Person parent;
        int child_id;
        Person child;
        string? who;

        //Используется для клонирования
        private Relation(int id, int parent_id, Person parent, int child_id, Person child, string? who)
        {
            this.id = id;
            this.parent_id = parent_id;
            this.parent = parent;
            this.child_id = child_id;
            this.child = child;
            this.who = who;
        }

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Код родителя
        /// </summary>
        public int ParentId { get { return parent_id; } set { parent_id = value; } }

        /// <summary>
        /// Объект родителя
        /// </summary>
        public Person Parent { get { return parent; } private set { parent = value; } }

        /// <summary>
        /// Код ребёнка
        /// </summary>
        public int ChildId { get { return child_id; } set { child_id = value; } }

        /// <summary>
        /// Объект ребёнка
        /// </summary>
        public Person Child { get { return child; } private set { child = value; } }
        /// <summary>
        /// Кем является родитель ребёнку
        /// </summary>
        public string? Who { get { return who; } set { who = value; } }

        public object Clone() => new Relation(id, parent_id, parent, child_id, child, who);

        public override bool Equals(object? obj)
        {
            return Equals(obj as Relation);
        }

        public bool Equals(Relation? other)
        {
            return other is not null &&
                   id == other.id &&
                   parent_id == other.parent_id &&
                   EqualityComparer<Person>.Default.Equals(parent, other.parent) &&
                   child_id == other.child_id &&
                   EqualityComparer<Person>.Default.Equals(child, other.child) &&
                   who == other.who;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, parent_id, parent, child_id, child, who);
        }

        public static bool operator ==(Relation? left, Relation? right)
        {
            return EqualityComparer<Relation>.Default.Equals(left, right);
        }

        public static bool operator !=(Relation? left, Relation? right)
        {
            return !(left == right);
        }
    }
}
