using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(LiggAbpFrameworkCoreModule)
        )]
    public class LiduoAbpEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MigrationDbContext>();
        }
    }
}