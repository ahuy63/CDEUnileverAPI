using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class SurveyAnswerRepository : GenericRepository<SurveyAnswer>, ISurveyAnswerRepository
    {
        public SurveyAnswerRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {

        }
    }
}
