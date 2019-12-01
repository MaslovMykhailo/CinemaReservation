using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaReservation.Persisted.Entities
{
    public class ReservationTicket
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public Guid TicketId { get; set; }

        public Guid ReservationId { get; set; }

        public ReservationRecord Reservation { get; set; }
    }
}
