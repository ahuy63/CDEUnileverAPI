using CDEUnileverAPI.Models;

namespace CDEUnileverAPI.Core.IServices
{
    public interface ICMSService
    {
        Task<IEnumerable<Article>> GetAll();
        Task<bool> AddArticle(Article article);
        Task<Article> GetArticle(int id);
        Task<bool> DeleteArticle(int id);
        Task<bool> UpdateArticle(Article article);
    }
}
