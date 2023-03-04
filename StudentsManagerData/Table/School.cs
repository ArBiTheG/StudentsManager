using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsManagerData.Table
{
    public class School
    {
        int id;
        string? full_name;
        string? short_name;
        string? address;
        string? description;

        /// <summary>
        /// Код
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Полное наименование школы
        /// </summary>
        public string? FullName { get { return full_name; } set { full_name = value; } }

        /// <summary>
        /// Короткое наименование школы
        /// </summary>
        public string? ShortName { get { return short_name; } set { short_name = value; } }

        /// <summary>
        /// Адрес школы
        /// </summary>
        public string? Address { get { return address; } set { address = value; } }

        /// <summary>
        /// Описание школы
        /// </summary>
        public string? Description { get { return description; } set { description = value; } }
    }
}
