using Ligg.Abp.Application;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.Paged;
using Ligg.Base.DataModel.ServiceResult;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.HttpApi.Controllers
{
    [ApiController]
    [Route(Grouping.GroupName_cms + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_cms)]
    public class SitMtnController : AbpController
    {
        public SitMtnController()
        {
        }

        //#list
        [HttpPost]
        [Route("[action]")]
        public async Task<object> GetAll(string param)
        {
            return null;
        }

    }
}