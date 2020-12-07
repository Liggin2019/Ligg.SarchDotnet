using System;

namespace Ligg.Abp.Application.Contracts
{
    public class RoleListTreeDto:RoleDto
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public String Name { get; set; }


    }
}