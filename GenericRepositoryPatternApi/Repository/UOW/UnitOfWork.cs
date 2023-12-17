
using GenericRepositoryPatternApi.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace GenericRepositoryPatternApi.Repository.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbJewelsiteContext _dbJewelsiteContext;
        private IDbContextTransaction _transaction;
        private Dictionary<Type, object> _repositories;
        private bool disposed = false;
        public UnitOfWork(DbJewelsiteContext dbJewelsiteContext) { 
            _dbJewelsiteContext = dbJewelsiteContext;
            _repositories = new Dictionary<Type, object>();
        }
        public async Task BeginTransaction()
        {
            _transaction = await _dbJewelsiteContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAcync()
        {
            try
            {
                await _transaction.CommitAsync();
            }catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbJewelsiteContext?.Dispose();
                }
            }
            this.disposed = true;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as Repository<T>;
            }
            var repository = new Repository<T>(_dbJewelsiteContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbJewelsiteContext.SaveChangesAsync();
        }
    }
}
