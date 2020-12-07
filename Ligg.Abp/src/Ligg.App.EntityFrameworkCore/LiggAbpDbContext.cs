using Ligg.Abp.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Ligg.Abp.Domain;

namespace Ligg.Abp.EntityFrameworkCore
{
    //[ConnectionStringName("MySql")]
    [ConnectionStringName("SqlServer")]
    public class LiggAbpDbContext : AbpDbContext<LiggAbpDbContext>
    {
        public DbSet<Transaction> Transactions { get; set; }



        public LiggAbpDbContext(DbContextOptions<LiggAbpDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}