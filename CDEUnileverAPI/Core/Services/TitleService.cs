using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

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
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTitle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
