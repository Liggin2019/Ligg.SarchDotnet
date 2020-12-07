using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class MaterialRepository : EfCoreRepository<LiggAbpDbContext, Material, Guid>, IMaterialRepository
    {
        public MaterialRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<Material> objs)
        {
            await DbContext.Set<Material>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<Material> objs)
        {
            DbContext.Set<Material>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



