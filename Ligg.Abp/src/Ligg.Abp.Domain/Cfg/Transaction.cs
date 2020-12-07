using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class Transaction : Entity<Guid>
    {
        [Required]
        public int Type { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        [StringLength(StringMaxLength.Code)]
        public String Code { get; set; }

        [StringLength(StringMaxLength.Description)]
        public String DisplayName { get; set; }

        [StringLength(StringMaxLength.Description)]
        public String Description { get; set; }

        [StringLength(StringMaxLength.Code)]
        public String OrderTag { get; set; }

        public int ImageKey { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }


    }


}