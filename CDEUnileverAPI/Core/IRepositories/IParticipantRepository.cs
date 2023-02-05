using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IParticipantRepository : IGenericRepository<Survey_Participant>
    {
        Task<ICollection<Survey_Participant>> GetBySurveyId(int surveyId);
    }
}
