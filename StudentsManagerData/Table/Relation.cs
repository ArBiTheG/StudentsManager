using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Relation
    {
        int id;
        int parent_id;
        Person parent;
        int child_id;
        Person child;
        string? who;

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
    }
}
