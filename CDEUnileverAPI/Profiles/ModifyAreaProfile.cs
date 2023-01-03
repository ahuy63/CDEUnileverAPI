using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class ModifyAreaProfile : Profile
    {
        public ModifyAreaProfile() {
            CreateMap<AddAreaDTO, Area>()
                .ForMember(dest => dest.Name, frm => frm.MapFrom(x => x.Name));
        }
    }
}
