using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData.Table
{
    public interface IPerson
    {
        /// <summary>
        /// Имя личности
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество личности
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Фамилия личности
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get; }
    }
}
