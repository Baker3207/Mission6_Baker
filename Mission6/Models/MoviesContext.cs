using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        public DbSet<movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movie>()
                .Property(b => b.MovieId)
                .ValueGeneratedOnAdd();
        }
    }
}
