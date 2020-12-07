using System;
using Ligg.Abp.Application;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Ligg.Abp.Domain.Shared.Consts;
using Microsoft.AspNetCore.Http;

namespace Ligg.Abp.HttpApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]

    [ApiExplorerSettings(GroupName = Grouping.GroupName_com)]
 
    public class UsrAthController : AbpController
    {
        private readonly IUserService _usrService;
        
        public UsrAthController(IUserService usrService)
        {
            _usrService = usrService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> Logon(string userCode, string userPass)
        {
            return await _usrService.Logon(userCode, userPass);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResult> Login([FromBody] UserLogonDto content)
        {
            //throw new NotImplementedException("这是一个未实现的异常接口");
            var userCode = content.userCode;
            var userPass = content.password;
            var rst = await _usrService.Logon(userCode, userPass);
            if (rst.Success)
            {
                //check user permission for api&function
            }
            return rst;

        }



    }
}