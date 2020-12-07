using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class UnitRepository : EfCoreRepository<LiggAbpDbContext, Unit, Guid>, IUnitRepository
    {
        public UnitRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<Unit> objs)
        {
            await DbContext.Set<Unit>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<Unit> objs)
        {
            DbContext.Set<Unit>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



