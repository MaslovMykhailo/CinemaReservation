using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaReservation.Persisted.Entities;

namespace Cinema.BusinessLogic.Interfaces
{
    public interface IReservationTicketService
    {
        Task<ReservationTicket> AddAsync(ReservationTicket entity);
        Task<ReservationTicket> UpdateAsync(Guid id, ReservationTicket entity);
        Task<bool> RemoveAsync(Guid id);
        Task<ReservationTicket> GetAsync(Guid id);
        Task<List<ReservationTicket>> GetAllAsync();
        Task<List<ReservationTicket>> Find(Expression<Func<ReservationTicket, bool>> expression);
    }
}
