using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class SurveyService : ISurveyService
    {
        public IUnitOfWork _unitOfWork;

        public SurveyService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Survey survey)
        {
            try
            {
                await _unitOfWork.SurveyRepository.Add(survey);
                foreach (var participant in survey.Participants)
                {
                    participant.SurveyId= survey.Id;
                    await _unitOfWork.ParticipantRepository.Add(participant);
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Survey>> GetAll()
        {
            return await _unitOfWork.SurveyRepository.GetAllAsync();
        }

        public async Task<bool> SurveyAnswer(int participantId,IEnumerable<SurveyAnswer> surveyAnswer)
        {
            try
            {
                foreach (var item in surveyAnswer)
                {
                    item.ParticipantId= participantId;
                    await _unitOfWork.SurveyAnswerRepository.Add(item);
                }

                var participant = await _unitOfWork.ParticipantRepository.GetById(participantId);
                participant.IsCompleted = true;
                await _unitOfWork.ParticipantRepository.Update(participant);

                await _unitOfWork.CommitAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Survey> SurveyResult(int surveyId)
        {
            var survey = await _unitOfWork.SurveyRepository.GetResult(surveyId);
            return survey;
        }
    }
}
