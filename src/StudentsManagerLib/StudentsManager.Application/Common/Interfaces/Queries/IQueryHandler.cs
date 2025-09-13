using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Queries
{
    /// <summary>
    /// Интерфейс обработчика запроса
    /// </summary>
    /// <typeparam name="TQuery">Параметр запроса</typeparam>
    /// <typeparam name="TResult">Параметр результата запроса</typeparam>
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery, new()
    {
        /// <summary>
        /// Выполняет обработку запроса и возращает результат запроса
        /// </summary>
        /// <param name="query">Объект запроса</param>
        /// <returns>Возращает результат запроса</returns>
        TResult Handle(TQuery query);
    }
}
