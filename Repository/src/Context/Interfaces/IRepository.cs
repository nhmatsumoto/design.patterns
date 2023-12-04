namespace nhmatsumoto.repository.pattern.Context.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }

}
