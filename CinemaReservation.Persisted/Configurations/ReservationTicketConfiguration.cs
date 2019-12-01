using CinemaReservation.Persisted.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservation.Persisted.Configurations
{
    public class ReservationTicketConfiguration : IEntityTypeConfiguration<ReservationTicket>
    {
        public void Configure(EntityTypeBuilder<ReservationTicket> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasQueryFilter(_ => !_.IsDeleted);
        }
    }
}
