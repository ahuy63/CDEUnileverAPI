using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class NotificationService : INotificationRepository
    {
        public readonly IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public Task<bool> Add(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
