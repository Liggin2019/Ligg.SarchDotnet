using Ligg.Abp.Application;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using static Ligg.Abp.Domain.Shared.Consts;
using Ligg.Base.DataModel;
using System;
using System.Collections.Generic;

namespace Ligg.Abp.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_com)]
    public class UsrRlvController : AbpController
    {
        private readonly IUserService _usrService;
        private readonly ITransactionService _transactionService;

        public UsrRlvController(IUserService usrService, ITransactionService transactionService)
        {
            _usrService = usrService;
            _transactionService = transactionService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResultT<UserAuthInfoDto>>GetAuthInfo()
        {
            var userCode = CurrentUser.UserName;
            return await _usrService.GetAuthInfo(); ;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<string>> GetPrf()
        {
            return null;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> PutPrf([FromBody] string  content)
        {
            return "";
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetLmn(string param)
        {
            return await _transactionService.GetLeftMenuItems(param);
        }



    }
}