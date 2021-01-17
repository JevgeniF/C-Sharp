using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BodyStyle> BodyStyles { get; set; } = default!;
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Expense> Expenses { get; set; } = default!;
        public DbSet<FuelType> FuelTypes { get; set; } = default!;
        public DbSet<Mark> Marks { get; set; } = default!;
        public DbSet<Transmission> Transmissions { get; set; } = default!;
    }
}