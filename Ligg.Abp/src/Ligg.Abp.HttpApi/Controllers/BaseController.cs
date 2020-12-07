using System;
using Ligg.Abp.Application;
using Ligg.Base.DataModel.ServiceResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;
using Ligg.Abp.Application.Contracts;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.HttpApi.Controllers
{
    [ApiController]
    public class BaseController : AbpController
    {

        protected void Authorize()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



    }
}