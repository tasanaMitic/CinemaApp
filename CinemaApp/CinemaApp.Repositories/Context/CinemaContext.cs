using CinemaApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }
        public DbSet<Cinemahall> CinemaHalls { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 #region genre
            modelBuilder.Entity<Genre>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Drama" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Sci-Fi" },
                new Genre { Id = 4, Name = "Romantic" },
                new Genre { Id = 5, Name = "Thriller" },
                new Genre { Id = 6, Name = "Horror" },
                new Genre { Id = 7, Name = "Crime" },
                new Genre { Id = 8, Name = "Mystery" }
                );
#endregion

            modelBuilder.Entity<Cinemahall>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Film>().HasIndex(x => new {x.Name, x.Director}).IsUnique();
            modelBuilder.Entity<FilmGenre>().HasIndex(x => new {x.FilmId, x.GenreId}).IsUnique();
        }


    }
}
