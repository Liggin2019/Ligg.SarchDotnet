using System;
using System.Collections.Generic;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ligg.Abp.EntityFrameworkCore
{
    public class OrganizationRepository : EfCoreRepository<LiggAbpDbContext, Organization, Guid>, IOrganizationRepository
    {
        public OrganizationRepository(IDbContextProvider<LiggAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<Organization> objs)
        {
            await DbContext.Set<Organization>().AddRangeAsync(objs);
            await DbContext.SaveChangesAsync();
        }

        public async Task BulkRemoveAsync(IEnumerable<Organization> objs)
        {
            DbContext.Set<Organization>().RemoveRange(objs);
            await DbContext.SaveChangesAsync();
        }
    }
}


//public class SignatureRepository : EfCoreRepository<MeowvBlogDbContext, Domain.Signature.Signature, Guid>, ISignatureRepository
//{
//    public SignatureRepository(IDbContextProvider<MeowvBlogDbContext> dbContextProvider) : base(dbContextProvider)
//    {


