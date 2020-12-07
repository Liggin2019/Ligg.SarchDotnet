using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class Organization : Entity<Guid>
    {
        public Guid? ParentId { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        [StringLength(StringMaxLength.Code)]
        public String Code { get; set; }

        [StringLength(StringMaxLength.Name)]
        public String ShortName { get; set; }

        [StringLength(StringMaxLength.Name)]
        public String DisplayName { get; set; }

        [StringLength(StringMaxLength.Code)]
        public String OrderTag { get; set; }

        public int ImageKey { get; set; }

        public bool Disabled { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }



    }


}