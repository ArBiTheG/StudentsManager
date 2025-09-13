using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Exceptions
{
    /// <summary>
    /// Представляет ошибки транзакции, возникающие во время выполнения приложения
    /// </summary>
    public class TransactionException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр TransactionException
        /// </summary>
        public TransactionException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр TransactionException с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, в котором описывается ошибка.</param>
        public TransactionException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр TransactionException с указанным сообщением об ошибке и ссылкой на внутреннее исключение, которое является причиной этого исключения.
        /// </summary>
        /// <param name="message">Сообщение, в котором описывается ошибка.</param>
        /// <param name="innerException">Исключение, которое является причиной текущего исключения, или нулевая ссылка</param>
        public TransactionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
