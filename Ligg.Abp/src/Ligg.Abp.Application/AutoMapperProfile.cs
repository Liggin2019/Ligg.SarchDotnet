using AutoMapper;
using Ligg.Abp.Application.Contracts;
using Ligg.Abp.Domain;

namespace Ligg.Abp.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Transaction, TransactionListTreeDto>();
            CreateMap<Transaction, TransactionMtnListDto>().ForMember(x => x.CreatorCode, opt => opt.Ignore()).ForMember(x => x.LastModifierCode, opt => opt.Ignore()).ForMember(x => x.TypeName, opt => opt.Ignore());
            CreateMap<Transaction, TransactionModDto>();

            CreateMap<Organization, OrganizationListTreeDto>();
            //CreateMap<Role, RoleMtnListDto>();


            CreateMap<User, UserMtnListDto>().ForMember(x => x.CreatorCode, opt => opt.Ignore()).ForMember(x => x.LastModifierCode, opt => opt.Ignore()).ForMember(x => x.StateFlag, opt => opt.Ignore());
            CreateMap<User, UserAddDto>();


        }
    }
}