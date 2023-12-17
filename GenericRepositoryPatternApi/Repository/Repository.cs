
using GenericRepositoryPatternApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GenericRepositoryPatternApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private DbJewelsiteContext _dbJewelsiteContext;
        public Repository(DbJewelsiteContext dbJewelsiteContext) {
            _dbSet = dbJewelsiteContext.Set<T>();   
            _dbJewelsiteContext = dbJewelsiteContext;
        } 
        public async Task<int> Delete(T entity)
        {
            _dbSet.Remove(entity);
            int response = await _dbJewelsiteContext.SaveChangesAsync();
            return response;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Post(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbJewelsiteContext.SaveChangesAsync();
            return entity;
        }

        public void SetDBCOntext(DbJewelsiteContext context)
        {
            _dbJewelsiteContext = context;
        }

        public async Task<int> Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbJewelsiteContext.Entry(entity).State = EntityState.Modified;
            int response = await _dbJewelsiteContext.SaveChangesAsync();
            return response;
        }
    }
}
