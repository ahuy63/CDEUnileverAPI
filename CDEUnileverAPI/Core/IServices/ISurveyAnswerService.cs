using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ISurveyAnswerService
    {
        Task<IEnumerable<SurveyAnswer>> GetAll();
    }
}
