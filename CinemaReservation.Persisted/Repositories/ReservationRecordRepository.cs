using Cinema.Persisted.Interfaces;
using CinemaReservation.Persisted.Context;
using CinemaReservation.Persisted.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.Persisted.Repositories
{
    public class ReservationRecordRepository : IReservationRecordRepository
    {
        protected readonly ReservationContext _context;
        private DbSet<ReservationRecord> _dbSet => _context.Set<ReservationRecord>();

        public ReservationRecordRepository(ReservationContext context)
        {
            _context = context;
        }

        public async Task<ReservationRecord> AddAsync(ReservationRecord entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;

        }

        public async Task<List<ReservationRecord>> GetAsync()
        {
            return await _dbSet.AsQueryable().ToListAsync();
        }

        public async Task<ReservationRecord> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);

            return true;
        }

        public async Task<ReservationRecord> UpdateAsync(Guid id, ReservationRecord entity)
        {
            _dbSet.Attach(entity);
            _context.Update(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<List<ReservationRecord>> Find(Expression<Func<ReservationRecord, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}
