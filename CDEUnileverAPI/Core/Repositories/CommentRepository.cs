using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CDEUnileverDbContext _context, ILogger logger):base(_context, logger)
        {

        }
        public async Task<int> GetNumberOFRating(int jobTaskId)
        {
            return _dbSet.Where(x => x.Rating != 0).Where(x => x.JobTaskId == jobTaskId).ToList().Count();
        }
        public async Task<double> GetSumRating(int jobTaskId)
        {
            return _dbSet.Where(x => x.Rating != 0).Where(x => x.JobTaskId == jobTaskId).Select(x => x.Rating).Sum();
        }

        public async Task<IEnumerable<Comment>> GetAllbyTask(int jobTaskId)
        {
            return await _dbSet.Where(x => x.JobTaskId == jobTaskId).Include(x => x.User).ToListAsync();
        }

    }
}
