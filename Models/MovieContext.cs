using Microsoft.EntityFrameworkCore;

namespace Drivers.Models
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options)
            : base(options)
        { }

        public DbSet<Driver> Drivers { get; set; } 
        public DbSet<Genre> Genres { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" },
                new Genre { GenreId = "C", Name = "Comedy" },
                new Genre { GenreId = "D", Name = "Drama" },
                new Genre { GenreId = "H", Name = "Horror" },
                new Genre { GenreId = "M", Name = "Musical" },
                new Genre { GenreId = "R", Name = "RomCom" },
                new Genre { GenreId = "S", Name = "SciFi" }
            );
            
            modelBuilder.Entity<Driver>().HasData(
                new Driver {
                    DriverId = 4,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreId = "D"
                },
                new Driver {
                    DriverId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A"
                },
                new Driver {
                    DriverId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R"
                }
            );
        }
    }
}