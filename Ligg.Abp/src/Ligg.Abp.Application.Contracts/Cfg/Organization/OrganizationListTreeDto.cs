using System;

namespace Ligg.Abp.Application.Contracts
{
    public class OrganizationListTreeDto: OrganizationDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

    }


}