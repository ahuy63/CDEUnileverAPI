using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Repositories
{
    public class QuestionaireRepository : GenericRepository<Questionaire>, IQuestionaireRepository
    {
        public QuestionaireRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
    }
}
