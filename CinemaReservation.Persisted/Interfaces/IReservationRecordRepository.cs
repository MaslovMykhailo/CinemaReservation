using CinemaReservation.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.Persisted.Interfaces
{
    public interface IReservationRecordRepository
    {
        Task<List<ReservationRecord>> GetAsync();

        Task<ReservationRecord> GetByIdAsync(Guid id);

        Task<ReservationRecord> AddAsync(ReservationRecord entity);

        Task<bool> RemoveAsync(Guid id);

        Task<ReservationRecord> UpdateAsync(Guid id, ReservationRecord entity);

        Task<List<ReservationRecord>> Find(Expression<Func<ReservationRecord, bool>> expression);
    }
}
