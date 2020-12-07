using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ligg.Base.DataModel.Paged;
using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using Ligg.Base.DataModel.ServiceResult;

namespace Ligg.Abp.Application
{
    public interface IRoleService
    {

        //#list
        Task<ServiceResultT<IEnumerable<RoleMtnListDto>>> ListRole();


    }
}
