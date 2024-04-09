using NZWalks6._0Framework.API.Models.Domain;

namespace NZWalks6._0Framework.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync();
    }
}
