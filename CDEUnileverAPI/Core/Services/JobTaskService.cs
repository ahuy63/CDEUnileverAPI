using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class JobTaskService : IJobTaskService
    {
        public readonly IUnitOfWork _unitOfWork;

        public JobTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddJobTask(JobTask jobTask)
        {
            try
            {
                await _unitOfWork.JobTaskRepository.Add(jobTask);
                var notification = new Notification
                {
                    UserId = jobTask.AssigneeId,
                    Title = "New Task",
                    Content = "New Task Assgined",
                    SenderId = jobTask.CreatedById
                };
                await _unitOfWork.NotiRepository.Add(notification);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteJobTask(int id)
        {
            try
            {
                var jobTask = await _unitOfWork.JobTaskRepository.GetById(id);
                if (jobTask != null)
                {
                    if (await _unitOfWork.JobTaskRepository.Delete(jobTask))
                    {
                        await _unitOfWork.CommitAsync();
                        return true;
                    }
                }
                return false;   
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<IEnumerable<JobTask>> Search(string keyword)
        {
            return await _unitOfWork.JobTaskRepository.Search(keyword);
        }

        public async Task<bool> UpdateJobTask(JobTask jobTask)
        {
            try
            {
                await _unitOfWork.JobTaskRepository.Update(jobTask);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
