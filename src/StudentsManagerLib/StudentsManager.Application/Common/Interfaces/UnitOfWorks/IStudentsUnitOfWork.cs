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
        ICuratorRepository Curators { get; }
        IGroupRepository Groups { get; }
        IPersonRepository Persons { get; }
        ISpecialtyRepository Specialties { get; }
        IStudentRepository Students { get; }
    }
}
