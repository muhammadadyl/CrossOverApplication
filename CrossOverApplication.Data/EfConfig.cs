using CrossOverApplication.Core.Domain.Entities;
using CrossOverApplication.Core.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrossOverApplication.Data
{
    public class EfConfig
    {
        public static void ConfigureEf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Image)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationIdentityUser>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationIdentityRole>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationIdentityUserClaim>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationIdentityRoleClaim>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
