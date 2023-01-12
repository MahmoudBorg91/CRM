using AutoMapper;
using GSI_Internal.Entites;
using GSI_Internal.Models;

namespace GSI_Internal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Custamer, CustomerVM>();
            CreateMap<FollowUP, FollowUpVM>();
            CreateMap<OurCompanyInfo, OurCompanyInfo_VM>();
        }
    }
}
