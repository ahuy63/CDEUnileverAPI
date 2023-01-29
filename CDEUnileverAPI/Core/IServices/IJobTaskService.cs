﻿using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IJobTaskService
    {
        public Task<IEnumerable<JobTask>> GetAll();
        public Task<bool> AddJobTask(JobTask jobTask);
        public Task<JobTask> GetJobTask(int id);
        public Task<bool> DeleteJobTask(int id);
        public Task<bool> UpdateJobTask(int id, JobTask jobTask);
    }
}