using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class ParticipantService : IParticipantService
    {
        public IUnitOfWork _unitOfWork;
        public ParticipantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public Task<bool> Add(Survey_Participant participant)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Survey_Participant>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
