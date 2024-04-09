using Microsoft.EntityFrameworkCore;
using NZWalks6._0Framework.API.Data;
using NZWalks6._0Framework.API.Models.Domain;

namespace NZWalks6._0Framework.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public SQLRegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _nZWalksDbContext.Regions.ToListAsync();
        }
    }
}
