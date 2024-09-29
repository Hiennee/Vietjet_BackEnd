﻿using Microsoft.EntityFrameworkCore;

namespace Vietjet_BackEnd.Models
{
    public class VietjetDbContext : DbContext
    {
        public VietjetDbContext(DbContextOptions<VietjetDbContext> options) : base(options) { }
        DbSet<Account> Accounts { get; set; }
        DbSet<Aircraft> Aircrafts { get; set; }
        DbSet<Compartment> Compartments { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Document_Version> DocumentVersions { get; set; }
        DbSet<Flight> Flights { get; set; }
        DbSet<SystemConfig> SystemConfigs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemConfig>()
                 .HasNoKey();
            modelBuilder.Entity<Compartment>()
                .HasOne(c => c.Flight)
                .WithMany(f => f.Compartments)
                .HasForeignKey(c => c.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Compartment>()
                .HasOne(c => c.Aircraft)
                .WithMany(a => a.Compartments)
                .HasForeignKey(c => c.AircraftId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Compartment>()
                .HasKey(c => new { c.AircraftId, c.FlightId, c.CompartmentId });
            modelBuilder.Entity<Document_Version>()
                .HasOne(dv => dv.Document)
                .WithMany(d => d.DocumentVersions)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
