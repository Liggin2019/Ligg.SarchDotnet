
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Ligg.Abp.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpAutoMapperModule)
        //typeof(LiduoAbpApplicationCachingModule)
        )]
    public class LiggAbpApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<LiggAbpApplicationModule>(validate: true);
                options.AddProfile<AutoMapperProfile>(validate: true);
            });
        }
    }
}