using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.Paged;
using Ligg.Base.DataModel.ServiceResult;
using System;
using System.Threading.Tasks;

namespace Ligg.Abp.Application
{
    public interface IUserService
    {

        //#list
        Task<ServiceResultT<PagedList<UserMtnListDto>>> ListUserByDepartment(string deptId, int pageIndex, int pageSize);
        Task<ServiceResultT<PagedList<UserMtnListDto>>> ListUserByRole(string rolId, int pageIndex, int pageSize);

        //#add
        Task<ServiceResult> AddUser(UserAddDto input);

        //#del
        Task<ServiceResult> DeleteUsers(String[] Ids);

        //#mod
        Task<ServiceResult> ModifyUser(UserModDto input);
        Task<ServiceResult> ChangePassword(UserModDto input);
        Task<ServiceResult> ChangeDepartment(Guid DeptId, String[] userIds);
        Task<ServiceResult> EnDisableUser(int type, Guid id);

        //#get
        Task<ServiceResultT<UserAddDto>> GetUser(Guid Id);
        Task<ServiceResultT<UserAuthInfoDto>> GetAuthInfo();


        //#other
        Task<ServiceResult> Logon(string userCode, string userPass);


    }
}
