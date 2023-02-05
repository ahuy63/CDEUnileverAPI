using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.Services
{
    public class CMSService : ICMSService
    {
        public IUnitOfWork _unitOfWork;

        public CMSService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<bool> AddArticle(Article article)
        {
            try
            {
                await _unitOfWork.CMSRepository.Add(article);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var article = await _unitOfWork.CMSRepository.GetById(id);
            if (article != null)
            {
                if (await _unitOfWork.CMSRepository.Delete(article))
                {
                    await _unitOfWork.CommitAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _unitOfWork.CMSRepository.GetAllAsync();
        }

        public async Task<Article> GetArticle(int id)
        {
            return await _unitOfWork.CMSRepository.GetById(id);
        }

        public async Task<bool> UpdateArticle(Article article)
        {
            try
            {
                await _unitOfWork.CMSRepository.Update(article);
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
