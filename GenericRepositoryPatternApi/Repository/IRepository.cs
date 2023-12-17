using GenericRepositoryPatternApi.Models;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Post(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        void SetDBCOntext(DbJewelsiteContext context);
    }
}
