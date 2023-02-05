using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        Task<Survey> GetResult(int id);
    }
}
