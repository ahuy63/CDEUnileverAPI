using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IQuestionnaireService
    {
        public Task<IEnumerable<Questionnaire>> GetAll();
        public Task<bool> AddNew(Questionnaire questionaire);
        public Task<Questionnaire> GetQuestionaire(int id);
        //public Task<bool> DeleteQuestionaire(int id);
        public Task<bool> UpdateQuestionaire(int id, Questionnaire questionaire);
        public Task<bool> AddNewQuestion(QuestionnaireDetail question);
        public Task<bool> UpdateQuestion(int questionId, QuestionnaireDetail question);
    }
}
