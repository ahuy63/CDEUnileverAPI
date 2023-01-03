namespace CDEUnileverAPI.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        //    Task<IEnumerable<T>> GetAll();
        //    Task<T> GetById(int id);
        //    Task<bool> Add(T entity);
        //    Task<bool> Delete(int id);
        //    Task<bool> Update(int id, T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
