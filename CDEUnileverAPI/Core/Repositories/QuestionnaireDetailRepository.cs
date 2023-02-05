using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class QuestionnaireDetailRepository : GenericRepository<QuestionnaireDetail>, IQuestionnaireDetailRepository
    {
        public QuestionnaireDetailRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger) { }

        public async Task<IEnumerable<QuestionnaireDetail>> GetByQuestionnaire(int questionnaireId)
        {
            return await _dbSet.Where(x => x.QuestionnaireId == questionnaireId).ToListAsync();
        }
    }
}
