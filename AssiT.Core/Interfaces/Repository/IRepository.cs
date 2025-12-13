using AssiT.Core.Entities;
using System.Linq.Expressions;

namespace AssiT.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<(ICollection<T>, int)> GetAll(Expression<Func<T, bool>> predicate, int Page);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> Insert(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
