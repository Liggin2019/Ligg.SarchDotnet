
using Ligg.Abp.Application;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.HttpApi.Controllers
{
    [ApiController]
    [Route(Grouping.GroupName_cfg + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_cfg)]
    public class OrgCfgController : BaseController
    {
        private readonly IOrganizationService _orgService;
        public OrgCfgController(IOrganizationService orgService)
        {
            _orgService = orgService;
        }

        //#list
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>> GetAll()
        {
            return await _orgService.GetAll();
        }

    }
}