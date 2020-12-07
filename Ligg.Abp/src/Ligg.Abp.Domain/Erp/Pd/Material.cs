using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class Material : Entity<Guid>
    {
        public int Type { get; set; }

        public long No { get; set; }

        public Guid NameId { get; set; }


        [StringLength(StringMaxLength.Description)]
        public String Specification { get; set; }


        [StringLength(StringMaxLength.Description)]
        public String OtherAttribute { get; set; }


        [StringLength(StringMaxLength.Description)]
        public String Stuff { get; set; }


        [StringLength(StringMaxLength.Description)]
        public String DrawingCode { get; set; }


        public Guid BasicUnitId { get; set; }

        public bool Disabled { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }

    }


}

