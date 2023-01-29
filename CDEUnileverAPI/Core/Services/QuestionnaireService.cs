using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper mapper;
        public QuestionnaireService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Questionnaire>> GetAll()
        {
            return await _unitOfWork.QuestionaireRepository.GetAllAsync();
        }

        public async Task<bool> AddNew(Questionnaire questionaire)
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

        public async Task<Questionnaire> GetQuestionaire(int id)
        {
            return await _unitOfWork.QuestionaireRepository.GetById(id);
        }

        public async Task<bool> UpdateQuestionaire(int id, Questionnaire questionaire)
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

        public async Task<bool> AddNewQuestion(QuestionnaireDetail question)
        {
            try
            {

                var questionaire = await _unitOfWork.QuestionaireRepository.GetById(question.QuestionnaireId);
                if (questionaire != null)
                {
                    questionaire.NumberOfQuestions += 1;
                    await _unitOfWork.QuestionaireDetailRepository.Add(question);
                    await _unitOfWork.QuestionaireRepository.Update(questionaire);
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

        public async Task<bool> UpdateQuestion(int questionId, QuestionnaireDetail question)
        {
            try
            {
                var existedQuestion = await _unitOfWork.QuestionaireDetailRepository.GetById(questionId);
                if (existedQuestion != null)
                {
                    //existedQuestion = question;
                    //question.Id= existedQuestion.Id;+9--*8][ \ n1 
                    //question.QuestionnaireId= existedQuestion.QuestionnaireId;
                    await _unitOfWork.QuestionaireDetailRepository.Update(question);
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


