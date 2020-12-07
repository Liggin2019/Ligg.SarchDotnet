using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Task BulkInsertAsync(IEnumerable<Role> objs);
        Task BulkRemoveAsync(IEnumerable<Role> objs);
    }
}