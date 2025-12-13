using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using AssiT.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssiT.Infra.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AssiTAppContext _context;

        public Repository(AssiTAppContext context)
        {
            _context = context;
        }

        public async Task Delete(T Entity)
        {
            Entity.SetAsDeleted();
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(e => e.IsDeleted == false).FirstOrDefaultAsync(predicate);
        }

        public async Task<(ICollection<T>, int)> GetAll(Expression<Func<T, bool>> predicate, int page=1)
        {
            IQueryable<T> query = _context.Set<T>().Where(e => !e.IsDeleted);

            if (predicate != null)
                query = query.Where(predicate);

            int total = await query.CountAsync();

            if (page == 0 )
            {
                return (
                    await query
                    .AsNoTracking()
                    .ToListAsync(), total
                    );
            }
            var result = await query
                .AsNoTracking()
                .Skip((page - 1) * 10)
                .Take(10)
                .ToListAsync();
            return (result, total);
        }

        public async Task<T> Insert(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
            return _context.SaveChangesAsync();
        }
    }
}
