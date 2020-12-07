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
    public class OrganizationService : ServiceBase, IOrganizationService
    {
        private readonly IOrganizationRepository _orgRepository;

        public OrganizationService(IOrganizationRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }

        //#list
        public async Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>> GetAll()
        {
            var result = new ServiceResultT<IEnumerable<OrganizationListTreeDto>>();

            var transactions = await _orgRepository.GetListAsync();

            var list = ObjectMapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationListTreeDto>>(transactions);
            list = list.OrderBy(x => x.OrderTag);
            result.IsSuccess(list);
            return result;
        }


        public async Task<ServiceResultT<IEnumerable<OrganizationListTreeDto>>> GetDepartments()
        {
            var result = new ServiceResultT<IEnumerable<OrganizationListTreeDto>>();
            var list = await _orgRepository.GetListAsync();

            var list1 = ObjectMapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationListTreeDto>>(list);
            var list2 = list1.Where(x => x.Type == (int)OrganizationType.Virtual | x.Type == (int)OrganizationType.Client | x.Type == (int)OrganizationType.Company | x.Type == (int)OrganizationType.Department).OrderBy(x => x.OrderTag);
            result.IsSuccess(list2);
            return result;
        }


    }
}
