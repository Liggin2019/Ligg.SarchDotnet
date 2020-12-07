using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class MaterialCategoryRepository : EfCoreRepository<LiggAbpDbContext, MaterialCategory, Guid>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<MaterialCategory> objs)
        {
            await DbContext.Set<MaterialCategory>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<MaterialCategory> objs)
        {
            DbContext.Set<MaterialCategory>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



