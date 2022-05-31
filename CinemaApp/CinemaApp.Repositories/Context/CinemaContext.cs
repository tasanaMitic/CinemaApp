using CinemaApp.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
