using Microsoft.EntityFrameworkCore;

namespace Places.Models
{

    public class MapContext : DbContext
    {

        public DbSet<Place> Places { get; set; }

        public MapContext(DbContextOptions<MapContext> opt) : base(opt)
        {

        }

    }

}