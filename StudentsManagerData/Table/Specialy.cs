using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public class Specialy
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

    }
}
