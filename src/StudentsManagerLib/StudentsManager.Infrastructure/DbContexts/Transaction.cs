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

        public async Task CommitAsync() => await _contextTransaction.CommitAsync();

        public async Task RollbackAsync() => await _contextTransaction.RollbackAsync();

        public void Dispose()
        {
            _contextTransaction?.Dispose();
        }
    }
}
