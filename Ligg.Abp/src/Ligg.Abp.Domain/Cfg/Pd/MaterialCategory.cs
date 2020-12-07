using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{

    public class MaterialCategory : Entity<Guid>
    {
        public Guid? ParentId { get; set; }

        public int Type { get; set; }

        public long No { get; set; }

        [Required]
        [StringLength(StringMaxLength.Name)]
        public String DisplayName { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }

    }



}

