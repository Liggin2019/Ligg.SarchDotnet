using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ligg.Abp.Domain.Contracts
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class LiduoAbpDomainSharedModule : AbpModule
    {

    }
}