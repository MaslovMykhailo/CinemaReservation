using Cinema.Persisted.Interfaces;
using CinemaReservation.Persisted.Context;
using CinemaReservation.Persisted.Entities;
using CinemaReservation.Persisted.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.Persisted.Repositories
{
    public class ReservationTicketRepository : IReservationTicketRepository
    {
        protected readonly ReservationContext _context;
        private DbSet<ReservationTicket> _dbSet => _context.Set<ReservationTicket>();

        public ReservationTicketRepository(ReservationContext context)
        {
            _context = context;
        }

        public async Task<ReservationTicket> AddAsync(ReservationTicket entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;

        }

        public async Task<List<ReservationTicket>> GetAsync()
        {
            return await _dbSet.AsQueryable().ToListAsync();
        }

        public async Task<ReservationTicket> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);

            return true;
        }

        public async Task<ReservationTicket> UpdateAsync(Guid id, ReservationTicket entity)
        {
            _dbSet.Attach(entity);
            _context.Update(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<List<ReservationTicket>> Find(Expression<Func<ReservationTicket, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}
