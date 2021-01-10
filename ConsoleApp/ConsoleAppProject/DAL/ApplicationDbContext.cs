using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SavedGame> SavedGames { get; set; } = null!;
        public DbSet<GameOptions> GameOptions { get; set; } = null!;
        public DbSet<DbBoat> Boats { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging()
                .UseSqlServer(@"
                Server=barrel.itcollege.ee,1533;
                User Id=student;
                Password=Student.Bad.password.0;
                Database=jefenk_battleShips;
                MultipleActiveResultSets=true;
                ");
        }
    }
}