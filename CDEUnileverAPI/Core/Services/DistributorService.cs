using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class DistributorService : IDistributorService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public DistributorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Distributor>> GetAll()
        {
            return await _unitOfWork.DistributorRepository.GetAllAsync();
        }

        public async Task<bool> AddDistributor(DistributorDTO distributorDto)
        {
            try
            {
                var mapped = _mapper.Map<Distributor>(distributorDto);
                var area = await _unitOfWork.AreaRepository.GetById(distributorDto.AreaId);
                area.DistributorQty += 1;
                await _unitOfWork.DistributorRepository.Add(mapped);
                await _unitOfWork.AreaRepository.Update(area);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Distributor> GetDistributor(int id)
        {
            return await _unitOfWork.DistributorRepository.GetById(id);
        }

        public async Task<bool> DeleteDistributor(int id)
        {
            try
            {
                var distributor = await _unitOfWork.DistributorRepository.GetById(id);
                
                if (distributor != null)
                {
                    var area = await _unitOfWork.AreaRepository.GetById(distributor.AreaId);
                    area.DistributorQty -= 1;
                    if (await _unitOfWork.DistributorRepository.Delete(distributor))
                    {
                        await _unitOfWork.AreaRepository.Update(area);
                        await _unitOfWork.CommitAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDistributor(int id, DistributorDTO distributorDto)
        {
            try
            {
                var mapped = _mapper.Map<Distributor>(distributorDto);
                var existingDistributor = await _unitOfWork.DistributorRepository.GetById(id);
                mapped.Id= existingDistributor.Id;
                if (existingDistributor != null)
                {
                    //await _unitOfWork.DistributorRepository.Update(mapped);
                    existingDistributor.Name = distributorDto.Name;
                    existingDistributor.Address = distributorDto.Address;
                    existingDistributor.SaleSupId = distributorDto.SaleSupId;
                    existingDistributor.Email = distributorDto.Email;
                    existingDistributor.Phone = distributorDto.Phone;
                    //existingDistributor = _mapper.Map<Distributor>(distributorDto);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Distributor>> GetDistributorByAreaId(int areaId)
        {
            return await _unitOfWork.DistributorRepository.GetByAreaIdAsync(areaId);
        }
    }
}
