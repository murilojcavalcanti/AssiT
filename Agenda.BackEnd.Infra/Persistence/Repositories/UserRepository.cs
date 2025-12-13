using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using AssiT.Infra.Persistence.Context;

namespace AssiT.Infra.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AssiTAppContext context):base(context)
        {
            
        }
    }
}
