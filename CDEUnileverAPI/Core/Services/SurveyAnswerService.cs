using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class SurveyAnswerService : ISurveyAnswerService
    {
        public IUnitOfWork _unitOfWork;
        public SurveyAnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public Task<IEnumerable<SurveyAnswer>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
