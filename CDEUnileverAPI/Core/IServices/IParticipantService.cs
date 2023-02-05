using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface IParticipantService
    {
        Task<IEnumerable<Survey_Participant>> GetAll();
        public Task<bool> Add(Survey_Participant participant);

    }
}
