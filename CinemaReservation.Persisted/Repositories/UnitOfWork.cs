using Cinema.Persisted.Interfaces;
using CinemaReservation.Persisted.Context;
using CinemaReservation.Persisted.Interfaces;
using System.Threading.Tasks;

namespace Cinema.Persisted.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservationContext _context;

        private IReservationRecordRepository _reservationRecordRepository;
        private IReservationTicketRepository _reservationTickerRepository;

        public UnitOfWork(ReservationContext context)
        {
            _context = context;
        }

        public IReservationRecordRepository ReservationRecordRepository =>
            _reservationRecordRepository ?? (_reservationRecordRepository = new ReservationRecordRepository(_context));

        public IReservationTicketRepository ReservationTicketRepository =>
            _reservationTickerRepository ?? (_reservationTickerRepository = new ReservationTicketRepository(_context));

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
