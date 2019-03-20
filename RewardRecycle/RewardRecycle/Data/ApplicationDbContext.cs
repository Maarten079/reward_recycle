using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RewardRecycle.Models;

namespace RewardRecycle.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RewardRecycle.Models.RewardModel> RewardModel { get; set; }

        // Added to seed Identity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        }

        // Added to seed Identity
        public DbSet<RewardRecycle.Models.RewardOrderModel> RewardOrderModel { get; set; }

        // Added to seed Identity
        public DbSet<RewardRecycle.Models.NfcCardModel> NfcCardModel { get; set; }
    }
}
