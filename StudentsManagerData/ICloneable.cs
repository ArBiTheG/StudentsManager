using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public interface ICloneable<TEntity>
    {
        /// <summary>
        /// Создает новый объект, который является копией текущего экземпляра.
        /// </summary>
        /// <returns>Новый объект, который является копией этого экземпляра.</returns>
        TEntity Clone();
    }
}
