using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class QuestionaireService : IQuestionaireService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper mapper;
        public QuestionaireService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Questionaire>> GetAll()
        {
            return await _unitOfWork.QuestionaireRepository.GetAllAsync();
        }

        public async Task<bool> AddNew(Questionaire questionaire)
        {
            try
            {
                await _unitOfWork.QuestionaireRepository.Add(questionaire);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Questionaire> GetQuestionaire(int id)
        {
            return await _unitOfWork.QuestionaireRepository.GetById(id);
        }

        public async Task<bool> UpdateQuestionaire(int id, Questionaire questionaire)
        {
            try
            {

                questionaire.Id = id;
                await _unitOfWork.QuestionaireRepository.Update(questionaire);
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
