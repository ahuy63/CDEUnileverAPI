using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IQuestionaireService
    {
        public Task<IEnumerable<Questionaire>> GetAll();
        public Task<bool> AddNew(Questionaire questionaire);
        public Task<Questionaire> GetQuestionaire(int id);
        //public Task<bool> DeleteQuestionaire(int id);
        public Task<bool> UpdateQuestionaire(int id, Questionaire questionaire);
    }
}
