using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Observers
{
    /// <summary>
    /// Представляет интерфейс субъекта наблюдения, позволяющего регистрировать, удалять и уведомлять подписчиков.
    /// </summary>
    /// <typeparam name="T">Тип передаваемых данных для уведомления.</typeparam>
    public interface IObservable<T>
    {
        /// <summary>
        /// Регистрация подписчика для получения уведомлений.
        /// </summary>
        /// <param name="subscriber">Объект который нужно зарегистрировать.</param>
        void RegisterSubscriber(IObserver<T> subscriber);
        /// <summary>
        /// Удаление зарегистрированного подписчика
        /// </summary>
        /// <param name="subscriber"></param>
        void RemoveSubscriber(IObserver<T> subscriber);
        /// <summary>
        /// Уведомление всех зарегистрированных подписчиков о произошедшем событии или изменении.
        /// </summary>
        /// <param name="data">Данные, передаваемые подписчикам для обработки.</param>
        void NotifySubscribers(T data);
    }
}
