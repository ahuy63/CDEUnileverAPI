using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class NotiService : INotiService
    {
        public Task<bool> AddNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteNotification(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetNotification(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNotification(int id, Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
