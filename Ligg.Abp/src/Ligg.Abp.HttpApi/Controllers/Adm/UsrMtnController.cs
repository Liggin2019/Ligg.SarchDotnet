using Ligg.Abp.Application;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.Paged;
using Ligg.Base.DataModel.ServiceResult;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.HttpApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route(Grouping.GroupName_adm + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_adm)]
    public partial class UsrMtnController : BaseController
    {
        private readonly IOrganizationService _orgService;
        private readonly IUserService _usrService;

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<PagedList<UserMtnListDto>>> GetUsrs(string param, int param1, int param2)
        {
            if (param.IsNullOrEmpty()) return null;
            return await _usrService.ListUserByDepartment(param, param1, param2);
        }

        public UsrMtnController(IOrganizationService orgService, IUserService usrService)
        {
            _orgService = orgService;
            _usrService = usrService;
            //Authorize(_usrService);
            //var ee = HttpContext.User.Identity.Name;
            
        }

        //#list
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>>GetDeps()
        {
            return await _orgService.GetDepartments();
        }

        //#add
        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResult> AddUsr([FromBody] UserAddDto content)
        {
            return await _usrService.AddUser(content);
        }

        //#mod
        [HttpPut]
        [Route("[action]")]
        public async Task<ServiceResult> ModUsr([FromBody] UserModDto content)
        {
            return await _usrService.ModifyUser(content);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ServiceResult> ChgPsw([FromBody] UserModDto content)
        {
            Guid id = Guid.NewGuid();
            return await _usrService.ChangePassword(content);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> DsbUsr(Guid param)
        {
            return await _usrService.EnDisableUser(0, param);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> EnbUsr(Guid param)
        {
            return await _usrService.EnDisableUser(1, param);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> ChgDep(Guid param, string param1)
        {

            return await _usrService.ChangeDepartment(param, param1.Split(','));
        }


        //#del
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> DelUsrs(string param)
        {
            if (param == null | param == "") return null;
            var IdArray = param.Split(',');
            return await _usrService.DeleteUsers(IdArray);
        }

        //#get
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<UserAddDto>> GetUsr(Guid param)
        {
            return await _usrService.GetUser(param);
        }


    }
}