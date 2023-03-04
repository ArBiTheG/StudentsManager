using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Group
    {
        int id;
        string name;
        int spec_id;
        Specialy specialy;
        bool is_distant;
        string? about;
        DateTime date_created;
        DateTime date_release;

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
    }
}
