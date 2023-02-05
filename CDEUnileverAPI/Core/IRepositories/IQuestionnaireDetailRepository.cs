using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IQuestionnaireDetailRepository : IGenericRepository<QuestionnaireDetail>
    {
        Task<IEnumerable<QuestionnaireDetail>> GetByQuestionnaire(int questionnaireId);
    }
}
