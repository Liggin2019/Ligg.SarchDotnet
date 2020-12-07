using System;

namespace Ligg.Abp.Application.Contracts
{
    public class MaterialMtnListDto : MaterialDto
    {
        public Guid Id { get; set; }

        public string  StateFlag { get; set; }

        public string CreatorCode { get; set; }

        public DateTime CreationTime { get; set; }

        public string LastModifierCode { get; set; }

        public DateTime ModificationTime { get; set; }

    }


}