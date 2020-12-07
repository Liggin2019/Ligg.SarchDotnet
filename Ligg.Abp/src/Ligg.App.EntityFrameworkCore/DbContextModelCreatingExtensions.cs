
using Ligg.Abp.Domain;
using Ligg.Abp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using static Ligg.Abp.Domain.Contracts.DbConsts;

namespace Ligg.Abp.EntityFrameworkCore
{
    public static class DbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            //builder.Entity<Post>(b =>
            //{
            //   b.ToTable(Consts.DbTablePrefix + DbTableName.Posts);
            //    b.HasKey(x => x.Id);
            //    b.Property(x => x.Title).HasMaxLength(200).IsRequired();
            //    b.Property(x => x.Author).HasMaxLength(10);
            //    b.Property(x => x.Url).HasMaxLength(100).IsRequired();
            //    //b.Property(x => x.Html).HasColumnType("longtext").IsRequired();
            //    //b.Property(x => x.Markdown).HasColumnType("longtext").IsRequired();
            //    b.Property(x => x.Html).HasColumnType("text").IsRequired();
            //    b.Property(x => x.Markdown).HasColumnType("text").IsRequired();
            //    b.Property(x => x.Html).HasMaxLength(500).IsRequired();
            //    b.Property(x => x.Markdown).HasMaxLength(500).IsRequired();
            //    b.Property(x => x.CategoryId).HasColumnType("int");
            //    b.Property(x => x.CreationTime).HasColumnType("datetime");
            //});

            //#cfg
            builder.Entity<Organization>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixConfig + DbTableName.Organizations);
                b.HasKey(x => x.Id);

            });


            builder.Entity<Role>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixConfig + DbTableName.Roles);
                b.HasKey(x => x.Id);

            });

            builder.Entity<Transaction>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixConfig +DbTableName.Transactions);
                b.HasKey(x => x.Id);

            });

            //#adm
            builder.Entity<User>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixAdmin + DbTableName.Users);
                b.HasKey(x => x.Id);

            });

            //#biz-pd
            builder.Entity<Material>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixBusiniss + DbTableName.Materials);
                b.HasKey(x => x.Id);

            });

            //#biz-pd
            builder.Entity<MaterialCategory>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixConfig + DbTableName.MaterialCategories);
                b.HasKey(x => x.Id);

            });

            //#biz-pd
            builder.Entity<MaterialUnit>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixBusiniss + DbTableName.MaterialUnits);
                b.HasKey(x => x.Id);

            });

            //#biz-pd
            builder.Entity<Unit>(b =>
            {
                b.ToTable(DbConsts.DbTablePrefixConfig + DbTableName.Units);
                b.HasKey(x => x.Id);

            });










        }
    }
}