using System;

namespace Ligg.Abp.Application.Contracts
{
    public class UserLogonDto
    {
        public String langueCode { get; set; }
        public String tenantCode { get; set; }
        public String functionCode { get; set; }
        public String accountType { get; set; }
        public String userCode { get; set; }
        public String password { get; set; }

    }
}