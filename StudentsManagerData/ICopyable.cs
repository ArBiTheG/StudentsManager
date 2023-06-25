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
        /// Выполняет копирование значений с внешнего объекта, без создания нового объекта.
        /// </summary>
        /// <param name="paste">Объект в который будет выполнено копирование значений из текущего объекта.</param>
        void Copy(TEntity paste);
    }
}
