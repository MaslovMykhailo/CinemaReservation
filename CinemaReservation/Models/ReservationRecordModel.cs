using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class ReservationRecordModel : ReservationRecordBaseModel
    {
        public DateTime ReservationTime { get; set; }

        public DateTime PaymentTime { get; set; }

        public DateTime CancelationTime { get; set; }

        public IEnumerable<Guid> TicketIds { get; set; }
    }
}
