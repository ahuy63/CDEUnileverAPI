using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IAreaService
    {
        public Task<IEnumerable<Area>> GetAll();
        public Task<bool> AddArea(Area area);
        public Task<Area> GetArea(int id);
        public Task<bool> DeleteArea(int id);
        //public Task<bool> AddUserToArea(int userId, int areaId);
        //public Task<bool> AddDistributorToArea(int distributorId, int areaId);
    }
}
