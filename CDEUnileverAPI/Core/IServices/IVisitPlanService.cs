using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IVisitPlanService
    {
        public Task<IEnumerable<VisitPlan>> GetAll();
        public Task<bool> AddVisitPlan(VisitPlan visitplan);
        public Task<VisitPlan> GetVisitPlan(int id);
        public Task<bool> DeleteVisitPlan(int id);
        public Task<bool> UpdateVisitPlan(int id, VisitPlan visitPlan);
    }
}
