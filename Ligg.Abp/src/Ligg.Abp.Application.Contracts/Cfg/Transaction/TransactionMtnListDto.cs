using System;

namespace Ligg.Abp.Application.Contracts
{
    public class TransactionMtnListDto: TransactionDto
    {
        public Guid Id { get; set; }

        public string TypeName { get; set; }
        public string CreatorCode { get; set; }

        public DateTime? CreationTime { get; set; }

        public string LastModifierCode { get; set; }

        public DateTime? ModificationTime { get; set; }

    }
}