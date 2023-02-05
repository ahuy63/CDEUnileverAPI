using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class QuestionnaireDetailProfile : Profile
    {
        public QuestionnaireDetailProfile()
        {
            CreateMap<ShowQuestionDTO, QuestionnaireDetail>().ReverseMap();
            CreateMap<QuestionDTO, QuestionnaireDetail>().ReverseMap();
            CreateMap<QuestionnaireDetailDTO, QuestionnaireDetail>().ReverseMap()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(frm => frm.Question));
        }
    }
}
