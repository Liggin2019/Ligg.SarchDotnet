using Ligg.Abp.Domain;
using Ligg.Abp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class TransactionRepository : EfCoreRepository<LiggAbpDbContext, Transaction, Guid>, ITransactionRepository
    {
        public TransactionRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<Transaction> objs)
        {
            await DbContext.Set<Transaction>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<Transaction> objs)
        {
            DbContext.Set<Transaction>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



