using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {

        }
        public override async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Participants).ToListAsync();
        }
        public async Task<Survey?> GetResult(int id)
        {
            return await _dbSet.Where(x => x.Id == id)
                .Include(p => p.Participants.Where(x => x.IsCompleted)).ThenInclude(x=> x.Answers).ThenInclude(x => x.Question)
                .Include(x => x.Questionnaire)
                .FirstOrDefaultAsync();
        }
    }
}
