using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaReservation.Persisted.Entities;

namespace Cinema.BusinessLogic.Interfaces
{
    public interface IReservationRecordService
    {
        Task<ReservationRecord> AddAsync(ReservationRecord entity);
        Task<ReservationRecord> UpdateAsync(Guid id, ReservationRecord entity);
        Task<bool> RemoveAsync(Guid id);
        Task<ReservationRecord> GetAsync(Guid id);
        Task<List<ReservationRecord>> GetAllAsync();
        Task<List<ReservationRecord>> Find(Expression<Func<ReservationRecord, bool>> expression);
    }
}
