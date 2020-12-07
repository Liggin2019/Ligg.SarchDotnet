using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class UserRepository : EfCoreRepository<LiggAbpDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<User> objs)
        {
            await DbContext.Set<User>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<User> objs)
        {
            DbContext.Set<User>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}




