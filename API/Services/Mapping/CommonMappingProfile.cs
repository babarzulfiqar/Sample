using AutoMapper;
using Core.Domain.MasterData;
using Core.Dtos.MasterData;

namespace API.Services.Mapping
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
           
            CreateMap<AccountType, AccountTypeDto>();
            CreateMap<AccountTypeDto, AccountType>();

            CreateMap<Account, AccountDto>()
                .ForMember(c => c.AssignedToUserId, x => x.MapFrom(c => c.User.UserId))
                .ForMember(c => c.AssignedToUsername, x => x.MapFrom(c => c.User.Username))
                .ForMember(c => c.AssignedToFullName, x => x.MapFrom(c => c.User.FullName))
                .ForMember(c => c.AccountTypeName, x => x.MapFrom(c => c.AccountType.AccountTypeName))
                .ForMember(c => c.IndustryName, x => x.MapFrom(c => c.Industry.IndustryName))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(x => x.CreatedBy.FullName));
            CreateMap<AccountDto, Account>()
                .ForMember(x => x.UserId, x => x.MapFrom(c => c.AssignedToUserId));

           
            CreateMap<BusinessType, BusinessTypeDto>();
            CreateMap<BusinessTypeDto, BusinessType>();
           
        }
    }
}
