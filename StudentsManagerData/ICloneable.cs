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
        /// Создает новый объект, который является копией текущего объекта.
        /// </summary>
        /// <returns>Новый объект, который является копией текущего объекта.</returns>
        TEntity Clone();
    }
}
