using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface ITransactionRepository : IRepository<Transaction, Guid>
    {
        //Task BulkInsertAsync(IEnumerable<Transaction> transaction);
        Task BulkInsertAsync(IEnumerable<Transaction> objs);
        Task BulkRemoveAsync(IEnumerable<Transaction> objs);
    }
}