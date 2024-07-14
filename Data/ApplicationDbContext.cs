using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Country>  Countries { get; set; }
        public DbSet<Hotel>  Hotels { get; set; }


    }
}
