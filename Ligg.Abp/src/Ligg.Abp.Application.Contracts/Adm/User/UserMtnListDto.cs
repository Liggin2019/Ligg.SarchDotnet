using System;

namespace Ligg.Abp.Application.Contracts
{
    public class UserMtnListDto:UserDto
    {
        public Guid Id { get; set; }

        //public bool Disabled { get; set; }

        public string  StateFlag { get; set; }

        public string CreatorCode { get; set; }

        public DateTime? CreationTime { get; set; }

        public string LastModifierCode { get; set; }

        public DateTime? ModificationTime { get; set; }

    }


}