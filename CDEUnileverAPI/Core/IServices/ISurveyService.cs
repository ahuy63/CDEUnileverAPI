using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ISurveyService
    {
        Task<IEnumerable<Survey>> GetAll();
        Task<bool> Add(Survey survey);
        Task<bool> SurveyAnswer(int participantId, IEnumerable<SurveyAnswer> surveyAnswer);
        Task<Survey> SurveyResult(int surveyId);
    }
}
