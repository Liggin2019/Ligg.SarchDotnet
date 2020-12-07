using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task BulkInsertAsync(IEnumerable<User> objs);
        Task BulkRemoveAsync(IEnumerable<User> objs);
    }
}