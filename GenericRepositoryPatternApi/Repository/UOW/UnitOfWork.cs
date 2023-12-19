
using GenericRepositoryPatternApi.Models;
using GenericRepositoryPatternApi.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace GenericRepositoryPatternApi.Repository.UOW
{
    public partial class UnitOfWork
    {
        public IProductRepository _ProductRepository { get; }
    }
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly DbJewelsiteContext _dbJewelsiteContext;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;
        private Dictionary<Type, object> _repositories;
        private bool disposed = false;

        public UnitOfWork(DbJewelsiteContext dbJewelsiteContext,IServiceProvider serviceProvider) { 
            _dbJewelsiteContext = dbJewelsiteContext;
            _serviceProvider = serviceProvider;
            _repositories = new Dictionary<Type, object>();
            _ProductRepository = new ProductRepository.ProductRepository(_dbJewelsiteContext);
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

        TRepository IUnitOfWork.GetRepository<TRepository, TEntity>()
        {
            var respository = _serviceProvider.GetService<TRepository>();
            if(respository == null)
            {
                throw new InvalidOperationException($"Failed to get the repository of type {typeof(TRepository)}");
            }
            if(respository is IRepository<TEntity> genericRepository)
            {
                genericRepository.SetDBCOntext(_dbJewelsiteContext);
            }
            else
            {
                throw new InvalidOperationException($"Repository of type {typeof(TRepository)}");
            }
            return respository;
        }
    }
}
