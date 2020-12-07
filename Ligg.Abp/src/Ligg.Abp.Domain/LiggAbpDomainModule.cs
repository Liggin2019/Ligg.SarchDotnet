using Ligg.Abp.Domain.Contracts;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ligg.Abp.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(LiduoAbpDomainSharedModule)
    )]
    public class LiggAbpDomainModule : AbpModule
    {

    }
}