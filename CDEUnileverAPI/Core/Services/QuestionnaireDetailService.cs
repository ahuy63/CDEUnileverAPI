using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class QuestionnaireDetailService : IQuestionnaireDetailService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public QuestionnaireDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionnaireDetail>> GetQuestionList(int questionnaireId)
        {
            return await _unitOfWork.QuestionaireDetailRepository.GetByQuestionnaire(questionnaireId);
        }
    }
}
