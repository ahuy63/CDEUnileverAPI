using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class QuestionaireDetailRepository : GenericRepository<QuestionaireDetail>, IQuestionaireDetailRepository
    {
        public QuestionaireDetailRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger) { }

    }
}
