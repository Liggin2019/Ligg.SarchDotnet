using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class Role : Entity<Guid>
    {
        [StringLength(StringMaxLength.Code)]
        public string Code { get; set; }

        [Required]
        [StringLength(StringMaxLength.Name)]
        public string DisplayName { get; set; }

        [StringLength(StringMaxLength.Description)]
        public string Description { get; set; }

        [StringLength(StringMaxLength.Code)]
        public string OrderTag { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }

    }

}

