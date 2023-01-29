using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class QuestionnaireDetailRepository : GenericRepository<QuestionnaireDetail>, IQuestionnaireDetailRepository
    {
        public QuestionnaireDetailRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger) { }

    }
}
