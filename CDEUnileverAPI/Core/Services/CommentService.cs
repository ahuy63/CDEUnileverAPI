﻿using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class CommentService : ICommentService
    {
        public IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddComment(Comment comment)
        {
            try
            {
                var jobTask = await _unitOfWork.JobTaskRepository.GetById(comment.JobTaskId);
                var rate_times = await _unitOfWork.CommentRepository.GetNumberOFRating(comment.JobTaskId);
                if (comment.Rating != 0)
                {
                    jobTask.Rating = (jobTask.Rating + comment.Rating) / (rate_times + 1);
                }
                await _unitOfWork.CommentRepository.Add(comment);
                await _unitOfWork.JobTaskRepository.Update(jobTask);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllbyTask(int jobTaskId)
        {
            return await _unitOfWork.CommentRepository.GetAllbyTask(jobTaskId);
        }
    }
}
