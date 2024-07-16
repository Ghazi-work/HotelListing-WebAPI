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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                              new Country
                              {
                                  Id = 1,
                                  Name = "United States",
                                  ShortName = "US"
                              },
                new Country
                {
                    Id = 2,
                    Name = "Canada",
                    ShortName = "CA"
                },
                new Country
                {
                    Id = 3,
                    Name = "United Kingdom",
                    ShortName = "UK"
                }


                );


            // Seed data for Hotel
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel California",
                    Address = "42 Sunset Blvd, Los Angeles, CA",
                    Rating = 4.7,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Fairmont Royal York",
                    Address = "100 Front St W, Toronto, ON",
                    Rating = 4.6,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "The Ritz London",
                    Address = "150 Piccadilly, St. James's, London",
                    Rating = 4.8,
                    CountryId = 3
                }
            );

        }


    }
}
