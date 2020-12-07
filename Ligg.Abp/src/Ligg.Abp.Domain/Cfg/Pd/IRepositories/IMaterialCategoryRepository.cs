using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IMaterialCategoryRepository : IRepository<MaterialCategory, Guid>
    {
        Task BulkInsertAsync(IEnumerable<MaterialCategory> objs);
        Task BulkRemoveAsync(IEnumerable<MaterialCategory> objs);
    }
}