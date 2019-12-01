using CinemaReservation.Persisted.Configurations;
using CinemaReservation.Persisted.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Persisted.Context
{
    public sealed class ReservationContext : DbContext
    {
        public DbSet<ReservationRecord> Reservations  { get; set; }

        public ReservationContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReservationRecordConfiguration());
        }
    }
}
