using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using System.Collections.Generic;

namespace CDEUnileverAPI.Profiles
{
    public class QuestionnaireProfile : Profile
    {
        public QuestionnaireProfile()
        {
            CreateMap<AddNewQuestionaireDTO, Questionnaire>().ReverseMap();
            CreateMap<ShowAllQuestionaireDTO, Questionnaire>().ReverseMap();
            CreateMap<AddNewQuestionDTO, QuestionnaireDetail>().ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDetailsDTO>().ReverseMap();

            CreateMap<QuestionnaireDetail, ShowQuestionDTO>().ReverseMap()
                //.ForMember(dest => dest.QuestionnaireId, opt => opt.Ignore())
                //.ForMember(dest => dest.Questionnaire, opt => opt.Ignore())
                //.ForMember(dest => dest.Question, opt => opt.MapFrom(frm => frm.Question))
                //.ForMember(dest => dest.AnswerA, opt => opt.MapFrom(frm => frm.AnswerA))
                //.ForMember(dest => dest.AnswerB, opt => opt.MapFrom(frm => frm.AnswerB))
                //.ForMember(dest => dest.AnswerC, opt => opt.MapFrom(frm => frm.AnswerC))
                //.ForMember(dest => dest.AnswerD, opt => opt.MapFrom(frm => frm.AnswerD))
                //.ForMember(dest => dest.AnswerE, opt => opt.MapFrom(frm => frm.AnswerE))
                //.ForMember(dest => dest.QuestionnairePart, opt => opt.MapFrom(frm => frm.QuestionarePart))
                //.ForMember(dest => dest.IsMultipleAns, opt => opt.MapFrom(frm => frm.IsMultipleAns))
                ;
            CreateMap<ShowQuestionDTO, Questionnaire>().ReverseMap();
            //CreateMap<QuestionnaireDetail, ShowQuestionDTO>().ReverseMap();
        }

    }
}
