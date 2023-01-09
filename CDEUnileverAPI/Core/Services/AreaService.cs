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
        public async Task<bool> AddArea(AddAreaDTO areaDto)
        {
            try
            {
                var mappedArea = _mapper.Map<Area>(areaDto);
                mappedArea.Code = "COD" + mappedArea.Id;
                await _unitOfWork.AreaRepository.Add(mappedArea);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<ShowAreaDTO>> GetAll()
        {
            var List = await _unitOfWork.AreaRepository.GetAllAsync();
            var mapped = List.Select(x => _mapper.Map<Area, ShowAreaDTO>(x));
            //return await _unitOfWork.AreaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShowAreaDTO>> (await _unitOfWork.AreaRepository.GetAllAsync());
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

        public async Task<ShowAreaDetailDTO> GetArea(int id)
        {
            return _mapper.Map<ShowAreaDetailDTO> (await _unitOfWork.AreaRepository.GetById(id));
        }

        public async Task<bool> AddUserToArea(int userId, int areaId)
        {
            try
            {
                await _unitOfWork.AreaRepository.AddUserToArea(userId, areaId);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public async Task<bool> AddDistributorToArea(int distributorId, int areaId)
        {
            try
            {
                await _unitOfWork.AreaRepository.AddDistributorToArea(distributorId, areaId);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
