using NZWalks6._0Framework.API.Models.Domain;

namespace NZWalks6._0Framework.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(Guid regionId);
        Task<Region> AddRegionAsync(Region region);
        Task<Region?>  DeleteRegionAsync(Guid regionId);
        Task<Region?> UpdateRegionAsync(Guid regionId, Region region);
    }
}
