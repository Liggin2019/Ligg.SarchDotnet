using System;

namespace Ligg.Abp.Application.Contracts
{
    public class MaterialAddDto : MaterialDto
    {
        public Guid MaterialCategoryId { get; set; }
        public Guid MaterialSubCategoryId { get; set; }

    }


}