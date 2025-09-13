using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Observers
{
    /// <summary>
    /// Представляет интерфейс наблюдателя за событиями или изменениями, получающего уведомления от субъекта.
    /// </summary>
    /// <typeparam name="T">Тип получаемых данных для уведомления.</typeparam>
    public interface IObserver<T>
    {
        /// <summary>
        /// Обработчик уведомлений о событии или изменении данных.
        /// </summary>
        /// <param name="data">Полученные данные для обработки.</param>
        void Update(T data);
    }
}
