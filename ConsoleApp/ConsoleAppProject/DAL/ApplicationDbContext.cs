using System;
using System.Net.NetworkInformation;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameOption> GameOptions { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<GameOptionBoat> GameOptionBoats { get; set; } = null!;
        public DbSet<Boat> Boats { get; set; } = null!;
        public DbSet<GameBoat> GameBoats { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}