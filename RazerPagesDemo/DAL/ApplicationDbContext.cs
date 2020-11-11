using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GpsSession> GpsSessions { get; set; }
        public DbSet<GpsLocation> GpsLocations { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
    }
}