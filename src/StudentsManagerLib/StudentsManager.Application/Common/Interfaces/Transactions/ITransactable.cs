using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Transactions
{
    public interface ITransactable
    {
        ITransaction BeginTransaction();
    }
}
