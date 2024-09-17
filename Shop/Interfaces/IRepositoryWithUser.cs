namespace Shop.Interfaces
{
    public interface IRepositoryWithUser<T> where T : class
    {
        Task<T> GetByIdAsync(int userId, int entityId);
        Task<IEnumerable<T>> GetAllAsync( int userId);
        Task Add(int userId, T entity);
        Task AddRange(int userId, List<T> entitys);
        Task Update(int userId, T entity);
        Task Delete(int entityId);


    }
}
