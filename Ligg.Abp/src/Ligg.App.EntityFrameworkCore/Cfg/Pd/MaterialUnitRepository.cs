using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class MaterialUnitRepository : EfCoreRepository<LiggAbpDbContext, MaterialUnit, Guid>, IMaterialUnitRepository
    {
        public MaterialUnitRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<MaterialUnit> objs)
        {
            await DbContext.Set<MaterialUnit>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<MaterialUnit> objs)
        {
            DbContext.Set<MaterialUnit>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



