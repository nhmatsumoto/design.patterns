using Microsoft.EntityFrameworkCore;
using nhmatsumoto.repository.pattern.Context.Entities;
using nhmatsumoto.repository.pattern.Context.Interfaces;

namespace nhmatsumoto.repository.pattern.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContextOptions<AppDbContext> options)
        {
            _context = new AppDbContext(options);
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }
               
            var repository = new Repository<T>(_context);
            _repositories[typeof(T)] = repository;

            return repository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
