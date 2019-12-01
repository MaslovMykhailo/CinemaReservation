using CinemaReservation.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaReservation.Persisted.Interfaces
{
    public interface IReservationTicketRepository
    {
        Task<List<ReservationTicket>> GetAsync();

        Task<ReservationTicket> GetByIdAsync(Guid id);

        Task<ReservationTicket> AddAsync(ReservationTicket entity);

        Task<bool> RemoveAsync(Guid id);

        Task<ReservationTicket> UpdateAsync(Guid id, ReservationTicket entity);

        Task<List<ReservationTicket>> Find(Expression<Func<ReservationTicket, bool>> expression);
    }
}