using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class ParticipantRepository : GenericRepository<Survey_Participant>, IParticipantRepository
    {
        public ParticipantRepository(CDEUnileverDbContext _context, ILogger logger) : base(_context, logger)
        {
        }
        public async Task<ICollection<Survey_Participant>> GetBySurveyId(int surveyId)
        {
            return await _dbSet.Where(x => x.SurveyId == surveyId).Where(x => x.IsCompleted == true).Include(x => x.Answers).ThenInclude(x => x.Question).ToListAsync();
        }
    }
}
