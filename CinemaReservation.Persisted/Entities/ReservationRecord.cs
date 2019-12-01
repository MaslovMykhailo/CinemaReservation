using System;
using System.Collections.Generic;

namespace CinemaReservation.Persisted.Entities
{
    public class ReservationRecord
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public Guid VisitorId { get; set; }

        public virtual ICollection<ReservationTicket> Tickets { get; set; }

        public DateTime ReservationTime { get; set; }

        public bool WasPaid { get; set; }
        
        public DateTime PaymentTime { get; set; }

        public bool WasCanceled { get; set; }

        public DateTime CancelationTime { get; set; }
    }
}
