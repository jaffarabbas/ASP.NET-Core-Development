using GenericRepositoryPatternApi.Repository.ProductRepository;

namespace GenericRepositoryPatternApi.Repository.UOW
{
    public partial interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
    }
    public partial interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task BeginTransaction();
        Task CommitAcync();
        Task RollBackAsync();
    }
}
