using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Commands
{
    /// <summary>
    /// Интерфейс обработчика команды
    /// </summary>
    /// <typeparam name="TCommand">Пареметр команды</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand, new()
    {
        /// <summary>
        /// Выполняет обработку команды
        /// </summary>
        /// <param name="command">Объект команды</param>
        void Handle(TCommand command);
    }
}
