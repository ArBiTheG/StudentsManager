﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Interfaces.Transactions
{
    /// <summary>
    /// Интерфейс транзакции
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Зафиксировать изменения
        /// </summary>
        void Commit();
        /// <summary>
        /// Отменить изменения
        /// </summary>
        void Rollback();
    }
}
