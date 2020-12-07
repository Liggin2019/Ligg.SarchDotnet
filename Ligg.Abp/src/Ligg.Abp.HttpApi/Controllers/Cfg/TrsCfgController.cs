
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
    [ApiController]
    [Route(Grouping.GroupName_cfg + "/[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_cfg)]
    public class TrsCfgController : AbpController
    {
        private readonly ITransactionService _transactionService;
        public TrsCfgController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //#list
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetAll()
        {
            return await _transactionService.GetAllTransactions();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<PagedList<TransactionMtnListDto>>> GetCds(string param, int param1, int param2)
        {
            return await _transactionService.GetChildsForMtn(param,param1,param2);
        }

        //#add
        [HttpPost]
        [Route("[action]")]
        public async Task<ServiceResult> AddTrs([FromBody] TransactionAddDto content)
        {
            return await _transactionService.AddTransaction(content);
        }

        //#mod
        [HttpPut]
        [Route("[action]")]
        public async Task<ServiceResult> ModTrs([FromBody] TransactionModDto content)
        {
            return await _transactionService.ModifyTransaction(content);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> ChgPrt(Guid param, string param1)
        {

            return await _transactionService.ChangeParent(param, param1.Split(','));
        }

        //#del
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResult> DelTrss(string param)
        {
            if (param == null | param == "") return null;
            var IdArray = param.Split(',');
            return await _transactionService.DeleteTransactions(IdArray);
        }

        //#get
        //##get for mod
        [HttpGet]
        [Route("[action]")]
        public async Task<ServiceResultT<TransactionModDto>> GetTrs(Guid param)
        {
            return await _transactionService.GetTransaction(param);
        }


    }
}