using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IJobTaskRepository : IGenericRepository<JobTask>
    {
        public Task<IEnumerable<JobTask>> GetByVisitPlanId(int visitPlanId);
        Task<IEnumerable<JobTask>> Search(string keyword);
    }
}
