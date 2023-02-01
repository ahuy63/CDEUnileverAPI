using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class JobTaskService : IJobTaskService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public JobTaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddJobTask(JobTask jobTask)
        {
            try
            {
                await _unitOfWork.JobTaskRepository.Add(jobTask);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> DeleteJobTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JobTask>> GetAll()
        {
            return await _unitOfWork.JobTaskRepository.GetAllAsync();
        }

        public async Task<IEnumerable<JobTask>> GetByVisitPlanId(int visitPlanId)
        {
            return await _unitOfWork.JobTaskRepository.GetByVisitPlanId(visitPlanId);
        }

        public async Task<JobTask> GetJobTask(int id)
        {
            return await _unitOfWork.JobTaskRepository.GetById(id);
        }

        public Task<bool> UpdateJobTask(int id, JobTask jobTask)
        {
            throw new NotImplementedException();
        }
    }
}
