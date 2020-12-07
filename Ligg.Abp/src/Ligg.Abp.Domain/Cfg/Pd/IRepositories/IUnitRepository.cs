using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IUnitRepository : IRepository<Unit, Guid>
    {
        Task BulkInsertAsync(IEnumerable<Unit> objs);
        Task BulkRemoveAsync(IEnumerable<Unit> objs);
    }
}