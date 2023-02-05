using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Profiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<SurveyDTO, Survey>().ReverseMap();
            CreateMap<ParticipantDTO, Survey_Participant>().ReverseMap();
            CreateMap<SurveyAnswerDTO, SurveyAnswer>().ReverseMap();
            CreateMap<SurveyDetailDTO, Survey>().ReverseMap()
                .ForMember(dest => dest.QuestionnaireTitle, opt => opt.MapFrom(frm => frm.Questionnaire.Title));
            CreateMap<ParticipantDetailDTO, Survey_Participant>().ReverseMap();
            CreateMap<ShowSurveyAnswerDTO, SurveyAnswer>().ReverseMap()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(frm => frm.Question.Question));
                //.ForMember(dest => dest.Answer, opt => opt.MapFrom(frm => frm.Question.AnswerA));
            CreateMap<SurveyListDTO, Survey>().ReverseMap();
        }
    }
}
