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
        }
    }
}
