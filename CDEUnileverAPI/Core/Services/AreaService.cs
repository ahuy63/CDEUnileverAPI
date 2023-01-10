using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class AreaService : IAreaService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public AreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddArea(Area area)
        {
            try
            {
                area.Code = "COD" + area.Id;
                await _unitOfWork.AreaRepository.Add(area);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Area>> GetAll()
        {
            return await _unitOfWork.AreaRepository.GetAllAsync();
        }

        public async Task<bool> DeleteArea(int id)
        {
            var area = await _unitOfWork.AreaRepository.GetById(id);
            if (area != null) {
                if (await _unitOfWork.AreaRepository.Delete(area))
                {
                    await _unitOfWork.CommitAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<Area> GetArea(int id)
        {
            return await _unitOfWork.AreaRepository.GetById(id);
        }
    }
}
