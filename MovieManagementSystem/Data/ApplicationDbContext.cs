using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieManagementSystem.Models;
namespace MovieManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Create a Movie table from the model
        public DbSet<Movie> Movies { get; set; }

        // Create a Studio table from the model
        public DbSet<Studio> Studios { get; set; }

        // Create an Actor table from the model
        public DbSet<Actor> Actors { get; set; }

    }
}
