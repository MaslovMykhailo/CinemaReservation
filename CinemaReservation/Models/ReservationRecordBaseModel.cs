using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class ReservationRecordBaseModel
    {
        public Guid Id { get; set; }

        public bool WasPaid { get; set; }

        public bool WasCanceled { get; set; }

        public Guid VisitorId { get; set; }
    }
}
