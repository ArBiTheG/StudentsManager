using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Application.Common.Interfaces.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.UnitOfWorks
{
    public interface IStudentsUnitOfWork: ITransactable
    {
        ICuratorRepository CuratorRepository { get; }
        IGroupRepository GroupRepository { get; }
        IPersonRepository PersonRepository { get; }
        ISpecialtyRepository SpecialtyRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}
