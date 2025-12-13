using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using AssiT.Infra.Persistence.Context;

namespace AssiT.Infra.Persistence.Repositories
{
    public class AssetRepository:Repository<Asset>,IAssetRepository
    {
        private readonly AssiTAppContext _context;
        public AssetRepository(AssiTAppContext context): base(context)
        {
            _context = context;
        }
    }
}
