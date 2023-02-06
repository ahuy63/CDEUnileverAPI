using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IVisitPlanRepository :IGenericRepository<VisitPlan>
    {
        Task<IEnumerable<VisitPlan>> Search(string keyword);
    }
}
