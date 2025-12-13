using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using AssiT.Infra.Persistence.Context;

namespace AssiT.Infra.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AssiTAppContext _context;
        public CategoryRepository(AssiTAppContext context): base(context)
        {
            _context = context;
        }
    }
}
