using System;

namespace Ligg.Abp.Application.Contracts
{
    public class TransactionListTreeDto: TransactionDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
       
    }
}