using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ITitleService
    {
        public Task<IEnumerable<Title>> GetAll();
        public Task<bool> AddTitle(TitleDTO title);
        public Task<Title> GetTitle(int id);
        public Task<bool> DeleteTitle(int id);
        public Task<bool> UpdateTitle(int id, TitleDTO title);
    }
}
