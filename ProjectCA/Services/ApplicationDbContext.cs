using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectCA.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace ProjectCA.Services
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<CalibrationRecord> CalibrationRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            base.OnModelCreating(builder);
            var tech = new IdentityRole("tech");
            tech.NormalizedName = "tech";

            builder.Entity<IdentityRole>().HasData(admin, tech);

            builder.Entity<EquipmentItem>()
                .HasOne(e => e.User)
                .WithMany(u => u.EquipmentItems)
                .HasForeignKey(e => e.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CalibrationRecord>()
        .HasOne(c => c.Equipment)
        .WithMany(e => e.CalibrationRecords)
        .HasForeignKey(c => c.EquipmentID)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CalibrationRecord>()
        .HasOne(c => c.User)
        .WithMany(u => u.CalibrationRecords)
        .HasForeignKey(c => c.UserID)
        .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
