using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
            {
         
                builder.ToTable("Cars");
                builder.HasOne(c => c.Garage)
                .WithMany(g => g.Cars)
                .HasForeignKey(c => c.GarageId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasData(
                    new Car
                    {
                        Id = 1,
                        Make = "Audi",
                        Model = "A4",
                        Year = 2016,
                        Type = Enums.VehicleType.Sedan,
                        IsAvailable = true,
                        GarageId = 1
                    },
                    new Car
                    {
                        Id = 2,
                        Make = "BMW",
                        Model = "X5",
                        Year = 2018,
                        Type = Enums.VehicleType.SUV,
                        IsAvailable = true,
                        GarageId = 1
                    },
                    new Car
                    {
                        Id = 3,
                        Make = "VW",
                        Model = "Golf",
                        Year = 2014,
                        Type = Enums.VehicleType.Hatchback,
                        IsAvailable = false,
                        GarageId = 2
                    }
                    );
            }
    }
}
