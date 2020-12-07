using System;

namespace Ligg.Abp.Application.Contracts
{
    public class TransactionDto
    {
        public String Code { get; set; }


        public int Type { get; set; }


        public String DisplayName { get; set; }

        public String Description { get; set; }


        public string OrderTag { get; set; }

        public int ImageKey { get; set; }

    }
}