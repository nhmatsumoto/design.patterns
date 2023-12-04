using nhmatsumoto.repository.pattern.Context.Entities;

namespace nhmatsumoto.repository.pattern.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<T> GetRepository<T>() where T : class;
    }

}
