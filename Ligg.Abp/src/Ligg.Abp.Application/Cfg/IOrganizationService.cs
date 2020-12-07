using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligg.Abp.Application
{
    public interface  IOrganizationService
    {

        //#list
        Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>> GetAll();

        Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>> GetDepartments();




    }
}
