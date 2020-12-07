using System;
using Ligg.Base.DataModel;

namespace Ligg.Abp.Application.Contracts
{
    public class UserAuthInfoDto
    {
        public String UserCode { get; set; }
        public String AvatarUrl { get; set; }
   
        public String FunctionCode { get; set; }
        public String[] RoleCodes { get; set; }
        public String[] AccesibleViewCodes { get; set; }
        public ValueText[] AccesibleActions { get; set; }
    }
} 