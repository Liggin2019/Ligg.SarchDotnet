using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IMaterialRepository : IRepository<Material, Guid>
    {
        Task BulkInsertAsync(IEnumerable<Material> objs);
        Task BulkRemoveAsync(IEnumerable<Material> objs);
    }
}