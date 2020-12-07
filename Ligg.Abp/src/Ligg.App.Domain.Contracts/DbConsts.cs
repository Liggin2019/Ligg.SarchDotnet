namespace Ligg.Abp.Domain.Contracts
{
    public class DbConsts
    {
        public static class DbTableName
        {
            //#adm
            public const string Roles = "Roles";

            public const string Transactions = "Transactions";

            public const string Users = "Users";

            public const string Organizations = "Organizations";

            public const string Permissions = "Permissions";

            //#biz-pd
            public const string Materials = "Materials";
            public const string MaterialCategories = "MaterialCategories";
            public const string MaterialUnits = "MaterialUnits";
            public const string Units = "Units";

        }

        public const string DbTablePrefixAdmin = "Adm.";
        public const string DbTablePrefixConfig = "Cfg.";
        public const string DbTablePrefixBusiniss = "Biz.";

    }
}