using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс определяющий возможность сохранять изменения
    /// </summary>
    public interface ISaveableRepository
    {
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task SaveChangesAsync();
    }
}
