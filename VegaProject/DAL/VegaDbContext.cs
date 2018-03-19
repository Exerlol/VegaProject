using Microsoft.EntityFrameworkCore;
using VegaProject.Core.DomainModels;

namespace VegaProject.DAL
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Makes {get;set;}

        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options)
               :base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });

            modelBuilder.Entity<VehicleFeature>()
                .HasOne(v => v.Vehicle)
                .WithMany(vf => vf.Features)
                .HasForeignKey(v => v.VehicleId);

            modelBuilder.Entity<VehicleFeature>()
                .HasOne(f => f.Feature)
                .WithMany(vf => vf.VehicleFeatures)
                .HasForeignKey(f => f.FeatureId);
        }


    }
}