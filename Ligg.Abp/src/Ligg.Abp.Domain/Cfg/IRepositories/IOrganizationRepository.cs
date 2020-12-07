using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ligg.Abp.Domain.IRepositories
{
    public interface IOrganizationRepository : IRepository<Organization, Guid>
    {
        //Task BulkInsertAsync(IEnumerable<Transaction> transaction);
    }
}