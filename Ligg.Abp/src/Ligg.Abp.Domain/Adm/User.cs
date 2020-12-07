using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ligg.Abp.Domain.Shared;

namespace Ligg.Abp.Domain
{
    public class User : Entity<Guid>
    {
        [Required]
        //[Key, Column(Order = 1)]
        [StringLength(StringMaxLength.Code)]
        public String Code { get; set; }

        [Required]
        [StringLength(StringMaxLength.Name)]
        public String Name { get; set; }

        [StringLength(50)]
        public String Password { get; set; }

        [StringLength(50)]
        public String Email { get; set; }

        public Guid? DepartmentId { get; set; }

        public bool Disabled { get; set; }

        public bool Builtin { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime ModificationTime { get; set; }


    }



}

