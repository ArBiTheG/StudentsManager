using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Domain.Common
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public int Id { get; set; }
    }
}
