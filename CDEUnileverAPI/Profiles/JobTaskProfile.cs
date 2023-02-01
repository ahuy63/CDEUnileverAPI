using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class JobTaskProfile : Profile
    {
        public JobTaskProfile()
        {
            CreateMap<JobTask, JobTaskDTO>().ReverseMap();
            CreateMap<ShowJobTaskListDTO, JobTask> ().ReverseMap()
                .ForMember(dest => dest.AssigneeFullName, opt => opt.MapFrom(frm => frm.Assignee.FullName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status == true ? "In Progress":"Done"));
            CreateMap<ShowJobTaskDetailsDTO,JobTask > ().ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status == true ? "In Progress" : "Done")); ;
        }
    }
}
