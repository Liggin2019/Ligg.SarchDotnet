using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class RoleRepository : EfCoreRepository<LiggAbpDbContext, Role, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<Role> objs)
        {
            await DbContext.Set<Role>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<Role> objs)
        {
            DbContext.Set<Role>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}



