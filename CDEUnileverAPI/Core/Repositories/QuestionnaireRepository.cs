using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class QuestionnaireRepository : GenericRepository<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {

        }
        public override async Task<Questionnaire> GetById(int id)
        {
            return await _dbSet.Include(q => q.Questions).SingleOrDefaultAsync(q => q.Id == id);
        }

    }
}
