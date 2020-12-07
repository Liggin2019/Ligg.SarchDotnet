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
    [Route(Grouping.GroupName_oa_cfg + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_oa_cfg)]
    public class TabCfgController : AbpController
    {
        public TabCfgController()
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