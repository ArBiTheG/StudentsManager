using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public interface ICopyable<TEntity>
    {
        /// <summary>
        /// Выполняет копирование значений с внешнего объекта, без создания нового экземпляра
        /// </summary>
        /// <param name="entity">Объект с которого будут скопированы значения</param>
        void Copy(TEntity entity);
    }
}
