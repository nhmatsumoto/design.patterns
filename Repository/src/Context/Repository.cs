using Microsoft.EntityFrameworkCore;
using nhmatsumoto.repository.pattern.Context.Interfaces;

namespace nhmatsumoto.repository.pattern.Context
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync() => DbSet.AsQueryable();
        public async Task<T> GetByIdAsync(object id) => await DbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
        public void Insert(T entity) => DbSet.Add(entity);
 
        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entityToDelete = DbSet.Find(id) ?? throw new ArgumentNullException(nameof(id));
            Delete(entityToDelete);
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }
    }
}
