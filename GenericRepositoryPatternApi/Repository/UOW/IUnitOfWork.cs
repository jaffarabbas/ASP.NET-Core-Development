namespace GenericRepositoryPatternApi.Repository.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task BeginTransaction();
        Task CommitAcync();
        Task RollBackAsync();
    }
}
