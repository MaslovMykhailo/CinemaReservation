using Cinema.BusinessLogic.Interfaces;
using Cinema.Persisted.Interfaces;
using CinemaReservation.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.BusinessLogic.Services
{
    public class ReservationRecordService : IReservationRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReservationRecord> AddAsync(ReservationRecord record)
        {
            await _unitOfWork.ReservationRecordRepository.AddAsync(record);
            await _unitOfWork.CommitAsync();

            return record;
        }

        public async Task<List<ReservationRecord>> Find(Expression<Func<ReservationRecord, bool>> expression)
        {
            return await _unitOfWork.ReservationRecordRepository.Find(expression);
        }

        public async Task<List<ReservationRecord>> GetAllAsync()
        {
            return await _unitOfWork.ReservationRecordRepository.GetAsync();
        }

        public async Task<ReservationRecord> GetAsync(Guid id)
        {
            return await _unitOfWork.ReservationRecordRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _unitOfWork.ReservationRecordRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<ReservationRecord> UpdateAsync(Guid id, ReservationRecord hall)
        {
            var updatedHall = await _unitOfWork.ReservationRecordRepository.UpdateAsync(id, hall);
            await _unitOfWork.CommitAsync();

            return updatedHall;
        }
    }
}
