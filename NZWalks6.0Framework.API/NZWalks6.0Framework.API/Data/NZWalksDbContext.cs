using Microsoft.EntityFrameworkCore;
using NZWalks6._0Framework.API.Models.Domain;

namespace NZWalks6._0Framework.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        { 

        }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }


    }
}
