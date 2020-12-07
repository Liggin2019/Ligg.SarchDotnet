using System;

namespace Ligg.Abp.Application.Contracts
{
    public class OrganizationDto 
    {
        public int Type { get; set; }

        public String ShortName { get; set; }

        public String DisplayName { get; set; }

        public String OrderTag { get; set; }

    }


}