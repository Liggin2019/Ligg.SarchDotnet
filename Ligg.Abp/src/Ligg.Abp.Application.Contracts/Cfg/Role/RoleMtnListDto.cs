using System;

namespace Ligg.Abp.Application.Contracts
{
    public class RoleMtnListDto:RoleDto
    {
        public Guid Id { get; set; }

        public String Description { get; set; }


    }
}