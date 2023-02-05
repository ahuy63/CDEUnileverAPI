using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IQuestionnaireDetailService
    {
        Task<IEnumerable<QuestionnaireDetail>> GetQuestionList(int questionnaireId);
    }
}
