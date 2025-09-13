using Microsoft.EntityFrameworkCore.Storage;
using StudentsManager.Application.Common.Interfaces.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Infrastructure.DbContexts
{
    internal class Transaction : ITransaction, IDisposable
    {
        IDbContextTransaction _contextTransaction;

        public Transaction(IDbContextTransaction contextTransaction)
        {
            _contextTransaction = contextTransaction;
        }

        public void Commit() => _contextTransaction.Commit();

        public void Rollback() => _contextTransaction.Rollback();

        public void Dispose()
        {
            _contextTransaction?.Dispose();
        }
    }
}
