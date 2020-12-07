using Ligg.Abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ligg.Abp.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(LiggAbpApplicationModule)
        )]
    public class LiggAbpHttpApiModule : AbpModule
    {

    }
}