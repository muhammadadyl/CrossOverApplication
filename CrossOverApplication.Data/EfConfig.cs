using CrossOverApplication.Core.Domain.Entities;
using CrossOverApplication.Data.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
