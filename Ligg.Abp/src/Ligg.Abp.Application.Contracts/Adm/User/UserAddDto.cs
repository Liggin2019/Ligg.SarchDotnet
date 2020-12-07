using System;

namespace Ligg.Abp.Application.Contracts
{
    public class UserAddDto:UserDto
    {
        public Guid? DepartmentId { get; set; }
    }


}