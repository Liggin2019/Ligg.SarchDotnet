using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class MigrationDbContext : AbpDbContext<MigrationDbContext>
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}