using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class NotiService : INotiService
    {
        public readonly IUnitOfWork _unitOfWork;
        public NotiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddNotification(Notification notification)
        {
            try
            {
                await _unitOfWork.NotiRepository.Add(notification);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Notification>> GetAllByUser(int userId)
        {
            return await _unitOfWork.NotiRepository.GetAllByUser(userId);
        }

        public async Task<Notification> GetNotification(int id)
        {
            var a = await _unitOfWork.NotiRepository.GetById(id);
            return await _unitOfWork.NotiRepository.GetById(id);
        }
    }
}
