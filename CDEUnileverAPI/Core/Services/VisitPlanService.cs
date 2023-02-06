using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class VisitPlanService : IVisitPlanService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public VisitPlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddVisitPlan(VisitPlan visitplan)
        {
            try
            {
                await _unitOfWork.VisitPlanRepository.Add(visitplan);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> DeleteVisitPlan(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VisitPlan>> GetAll()
        {
            return await _unitOfWork.VisitPlanRepository.GetAllAsync();
        }

        public async Task<VisitPlan> GetVisitPlan(int id)
        {
            return await _unitOfWork.VisitPlanRepository.GetById(id);
        }

        public async Task<IEnumerable<VisitPlan>> Search(string keyword)
        {
            return await _unitOfWork.VisitPlanRepository.Search(keyword);
        }

        public Task<bool> UpdateVisitPlan(int id, VisitPlan visitPlan)
        {
            throw new NotImplementedException();
        }
    }
}
