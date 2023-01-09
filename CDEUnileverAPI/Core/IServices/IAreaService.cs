using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IAreaService
    {
        public Task<IEnumerable<ShowAreaDTO>> GetAll();
        public Task<bool> AddArea(AddAreaDTO area);
        public Task<ShowAreaDetailDTO> GetArea(int id);
        public Task<bool> DeleteArea(int id);
        public Task<bool> AddUserToArea(int userId, int areaId);
        public Task<bool> AddDistributorToArea(int distributorId, int areaId);
    }
}
