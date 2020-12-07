using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IMaterialUnitRepository : IRepository<MaterialUnit, Guid>
    {
        Task BulkInsertAsync(IEnumerable<MaterialUnit> objs);
        Task BulkRemoveAsync(IEnumerable<MaterialUnit> objs);
    }
}