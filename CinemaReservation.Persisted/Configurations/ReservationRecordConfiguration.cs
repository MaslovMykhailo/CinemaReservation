using CinemaReservation.Persisted.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservation.Persisted.Configurations
{
    public class ReservationRecordConfiguration : IEntityTypeConfiguration<ReservationRecord>
    {
        public void Configure(EntityTypeBuilder<ReservationRecord> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasQueryFilter(_ => !_.IsDeleted);

            builder.HasMany(_ => _.Tickets).WithOne(_ => _.Reservation);
        }
    }
}
