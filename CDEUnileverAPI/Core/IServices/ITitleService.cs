using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ITitleService
    {
        public Task<IEnumerable<TitleDTO>> GetAll();
        public Task<bool> AddTitle(TitleDTO title);
        public Task<TitleDTO> GetTitle(int id);
        public Task<bool> DeleteTitle(int id);
        public Task<bool> UpdateTitle(int id, TitleDTO title);
    }
}
