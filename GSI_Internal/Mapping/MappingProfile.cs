using AutoMapper;
using GSI_Internal.Entites;
using GSI_Internal.Models;

namespace GSI_Internal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskMain, TaskMain_VM>();

            //    CreateMap<Custamer, CustomerVM>();
            //    CreateMap<FollowUP, FollowUpVM>();
            //    CreateMap<OurCompanyInfo, OurCompanyInfo_VM>();
            //    CreateMap<ContactUs, ContactUsVM>();
            //    CreateMap<ContactUsVM ,ContactUs>();
            //    CreateMap<JopList, JopList_VM>();
            //    CreateMap<JopList_VM, JopList>();
        }
    }
}
