using System;

namespace Ligg.Abp.Application.Contracts
{
    public class TransactionAddDto:TransactionDto
    {
        public Guid ParentId { get; set; }

    }
}