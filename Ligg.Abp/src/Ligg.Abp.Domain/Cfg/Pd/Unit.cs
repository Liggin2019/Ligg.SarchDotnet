using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class Unit : Entity<Guid>
    {
        [StringLength(StringMaxLength.Code)]
        public String Code { get; set; }

        [Required]
        [StringLength(StringMaxLength.Name)]
        public String DisplayName { get; set; }

        [StringLength(StringMaxLength.Description)]
        public String Description { get; set; }

        public bool IsBasicUnit { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }

    }


}

