using System;
using System.Collections.Generic;

namespace CinemaReservation.Models
{
    public class ReservationModel
    {
        public IEnumerable<Guid> TicketIds { get; set; }

        public Guid VisitorId { get; set; }
    }
}
