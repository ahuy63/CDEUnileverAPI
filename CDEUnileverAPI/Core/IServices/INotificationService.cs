using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface INotificationService
    {
        public Task<IEnumerable<Notification>> GetAll();
        public Task<bool> AddNotification(Notification notification);
        public Task<Notification> GetNotification(int id);
        public Task<bool> DeleteNotification(int id);
        public Task<bool> UpdateNotification(int id, Notification notification);
    }
}
