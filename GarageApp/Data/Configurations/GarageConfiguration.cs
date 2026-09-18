using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configurations
{
    public class GarageConfiguration: IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
            {
            
                builder.ToTable("Garages");

                builder.HasData(
                    new Garage
                    {
                        Id = 1,
                        Name = "Central Garage",
                        Location = "Sofia"
                    },
                new Garage
                {
                    Id = 2,
                    Name = "Mointain Garage",
                    Location = "Plovdiv"
                }
                );
            }
    }
}
