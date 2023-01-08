using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnileverAPI.Core.Services
{
    public class TitleService : ITitleService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public TitleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Title>> GetAll()
        {
            return await _unitOfWork.TitleRepository.GetAllAsync();

        }

        public async Task<bool> AddTitle(TitleDTO titleDto)
        {
            try
            {
                var mappedTitle = _mapper.Map<Title>(titleDto);
                await _unitOfWork.TitleRepository.Add(mappedTitle);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<Title> GetTitle(int id)
        {
            return _unitOfWork.TitleRepository.GetById(id);
        }

        public async Task<bool> DeleteTitle(int id)
        {
            try
            {
                var title = await _unitOfWork.TitleRepository.GetById(id);
                if (title != null)
                {
                    if (await _unitOfWork.TitleRepository.Delete(title))
                    {
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

        public async Task<bool> UpdateTitle(int id, TitleDTO titleDto)
        {
            try
            {
                var mappedTitle = _mapper.Map<Title>(titleDto);
                var existingTitle = await _unitOfWork.TitleRepository.GetById(id);
                if (existingTitle != null)
                {
                    existingTitle.Name = titleDto.Name;
                    existingTitle.Description = titleDto.Description;
                    //existingTitle = _mapper.Map<TitleDTO, Title>(titleDto);
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
    }
}
