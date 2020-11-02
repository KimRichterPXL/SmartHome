using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace SmartHome.API.Models
{
    public class SmartHomeContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Light> Lights { get; set; }

        public SmartHomeContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Light>().Property(l => l.Name).IsRequired();
            builder.Entity<Light>().Property(l => l.ProductName).IsRequired();
            builder.Entity<Light>().Property(l => l.ProductId).IsRequired();

            builder.Entity<Light>().HasData(
                new Light
                {
                    Id = 1,
                    Name = "Staande lamp in Living",
                    ProductId = "00:17:88:01:00:bd:c7:b9-0b",
                    ProductName = "Hue color lamp 7"
                },
                new Light
                {
                    Id = 2,
                    Name = "Plafond lamp Tv",
                    ProductId = "00:17:88:11:00:bd:c7:b9-0b",
                    ProductName = "Philips Hue Filamentlamp White Standaard E27"
                },
                new Light
                {
                    Id = 3,
                    Name = "Plafond lamp Keuken",
                    ProductId = "00:17:99:11:00:bd:c7:b9-0b",
                    ProductName = "LED1732G11"
                },
                new Light
                {
                    Id = 4,
                    Name = "Plafond lamp Badkamer",
                    ProductId = "00:17:99:11:33:bd:c7:b9-0b",
                    ProductName = "LED1733G7"
                },
                new Light
                {
                    Id = 5,
                    Name = "Buitenverlichting slinger",
                    ProductId = "00:17:99:19:00:bd:c7:b9-0b",
                    ProductName = "LED1733G7"
                });

            base.OnModelCreating(builder);

        }

    }
}
