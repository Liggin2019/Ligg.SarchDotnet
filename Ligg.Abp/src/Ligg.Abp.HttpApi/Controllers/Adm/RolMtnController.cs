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
    [Route(Grouping.GroupName_adm + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_adm)]
    public partial class RolMtnController : AbpController
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RolMtnController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        //#list
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<RoleListTreeDto>>> GetRols()
        {
            //return await _roleService.GetAll();
            return null;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<PagedList<UserMtnListDto>>> GetUsrs(string param, int param1, int param2)
        {
            return await _userService.ListUserByRole(param, param1, param2);
        }



    }
}