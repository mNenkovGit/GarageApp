using GarageApp.Data.Configurations;
using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data
{
    public class GarageDbContext : DbContext
    {
        public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Garage> Garages { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GarageConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
