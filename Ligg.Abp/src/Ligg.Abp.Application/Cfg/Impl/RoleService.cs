using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using Ligg.Abp.Domain;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain.Shared.Enums;
using Ligg.Base.DataModel.Paged;
using Ligg.Base.DataModel.ServiceResult;
using Ligg.Base.Extensions;
using Microsoft.IdentityModel.Tokens;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.Application.Impl
{
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        //#role
        public async Task<ServiceResultT<IEnumerable<RoleMtnListDto>>> ListRole()
        {
            var result = new ServiceResultT<IEnumerable<RoleMtnListDto>>();
            var items = await _roleRepository.GetListAsync();

            var list = ObjectMapper.Map<IEnumerable<Role>, IEnumerable<RoleMtnListDto>>(items);
            result.IsSuccess(list);
            return result;
        }


    }
}
