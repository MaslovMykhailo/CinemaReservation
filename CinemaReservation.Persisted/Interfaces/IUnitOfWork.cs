using CinemaReservation.Persisted.Interfaces;
using System.Threading.Tasks;

namespace Cinema.Persisted.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRecordRepository ReservationRecordRepository { get; }
        IReservationTicketRepository ReservationTicketRepository { get; }

        Task CommitAsync();
    }
}
