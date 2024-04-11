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

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _nZWalksDbContext.Regions.AddAsync(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid regionId)
        {
            var existingRegionModel = await GetRegionByIdAsync(regionId);
            if (existingRegionModel == null)
            {
                return null;
            }
            _nZWalksDbContext.Regions.Remove(existingRegionModel);
            await _nZWalksDbContext.SaveChangesAsync();
            return existingRegionModel;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid regionId)
        {
            var regionDomainModel = await _nZWalksDbContext.Regions.FirstOrDefaultAsync(region=> region.Id == regionId);
            if (regionDomainModel == null)
            {
                return null;
            }
            return regionDomainModel;
        }

        public async Task<Region?> UpdateRegionAsync(Guid regionId, Region region)
        {
            var existRegionModel = await GetRegionByIdAsync(regionId);
            if (existRegionModel == null)
            {
                return null;
            }
            existRegionModel.Population = region.Population;
            existRegionModel.Lat = region.Lat;
            existRegionModel.Code = region.Code;
            existRegionModel.Walks = region.Walks;
            existRegionModel.Area = region.Area;
            existRegionModel.Population = region.Population;
            existRegionModel.Long = region.Long;
            await _nZWalksDbContext.SaveChangesAsync();
            return existRegionModel;
        }
    }
}
