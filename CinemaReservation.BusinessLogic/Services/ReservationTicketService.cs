using Cinema.BusinessLogic.Interfaces;
using Cinema.Persisted.Interfaces;
using CinemaReservation.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.BusinessLogic.Services
{
    public class ReservationTicketService : IReservationTicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationTicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReservationTicket> AddAsync(ReservationTicket record)
        {
            await _unitOfWork.ReservationTicketRepository.AddAsync(record);
            await _unitOfWork.CommitAsync();

            return record;
        }

        public async Task<List<ReservationTicket>> Find(Expression<Func<ReservationTicket, bool>> expression)
        {
            return await _unitOfWork.ReservationTicketRepository.Find(expression);
        }

        public async Task<List<ReservationTicket>> GetAllAsync()
        {
            return await _unitOfWork.ReservationTicketRepository.GetAsync();
        }

        public async Task<ReservationTicket> GetAsync(Guid id)
        {
            return await _unitOfWork.ReservationTicketRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _unitOfWork.ReservationTicketRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<ReservationTicket> UpdateAsync(Guid id, ReservationTicket hall)
        {
            var updatedHall = await _unitOfWork.ReservationTicketRepository.UpdateAsync(id, hall);
            await _unitOfWork.CommitAsync();

            return updatedHall;
        }
    }
}
