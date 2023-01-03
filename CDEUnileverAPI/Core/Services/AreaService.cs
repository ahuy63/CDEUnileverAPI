using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Area>> GetAll()
        {
            var List = await _unitOfWork.AreaRepository.GetAllAsync();
            var mapped = List.Select(x => _mapper.Map<Area, ShowAreaDTO>(x));
            //return await _unitOfWork.AreaRepository.GetAllAsync();
            return _mapper.Map<List<Area>>(List);
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

        public Task<Area> GetArea(int id)
        {
            return _unitOfWork.AreaRepository.GetById(id);
        }
    }
}
