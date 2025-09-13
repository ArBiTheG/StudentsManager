using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Exceptions
{
    /// <summary>
    /// Представляет ошибки репозитория, возникающие во время выполнения приложения
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр RepositoryException.
        /// </summary>
        public RepositoryException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр RepositoryException с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, в котором описывается ошибка.</param>
        public RepositoryException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр RepositoryException с указанным сообщением об ошибке и ссылкой на внутреннее исключение, которое является причиной этого исключения.
        /// </summary>
        /// <param name="message">Сообщение, в котором описывается ошибка.</param>
        /// <param name="innerException">Исключение, которое является причиной текущего исключения, или нулевая ссылка.</param>
        public RepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
