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
    [Route(Grouping.GroupName_erp_biz_pd + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_erp_biz_pd)]
    public class MatMtnController : AbpController
    {
        private readonly IMaterialService _materialService;

        public MatMtnController(IMaterialService materialService)
        {
            _materialService= materialService;
        }

        //#list
        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResultT<PagedList<MaterialMtnListDto>>> GetMats(string param, string[] param1)
        {
            //if (param.IsNullOrEmpty()) return null;
            //return await _usrService.GetMaterialsForMtn(param, param1);

            return null;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<RoleListTreeDto>>> GetCats(int param)
        {
            //return await _roleService.GetAll();
            return null;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<RoleListTreeDto>>> GetBasUnts()
        {
            //return await _roleService.GetAll();
            return null;
        }

        //#add
        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResult> AddMat([FromBody] MaterialAddDto content)
        {
            //return await _materialService.AddMaterial(content);
            return null;
        }

        //#mod
        [HttpPut]
        [Route("[action]")]
        public async Task<ServiceResult> ModMat([FromBody] MaterialModDto content)
        {
            //return await _usrService.ModifyUser(content);
            return null;
        }

    }
}