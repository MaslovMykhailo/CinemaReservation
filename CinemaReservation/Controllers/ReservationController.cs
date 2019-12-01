using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Cinema.BusinessLogic.Interfaces;
using CinemaReservation.Models;
using CinemaReservation.Persisted.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservation.Controllers
{
    [Route("api/reservation")]
    public class ReservationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReservationRecordService _reservationRecordService;
        private readonly IReservationTicketService _reservationTicketService;

        public ReservationController(IMapper mapper, IReservationRecordService reservationRecordService, IReservationTicketService reservationTicketService)
        {
            _mapper = mapper;
            _reservationRecordService = reservationRecordService;
            _reservationTicketService = reservationTicketService;
        }

        [HttpGet("{reservationId}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid reservationId)
        {
            var record = _mapper.Map<ReservationRecordModel>(await _reservationRecordService.GetAsync(reservationId));
            var ticketRecords = await _reservationTicketService.Find(_ => _.ReservationId == record.Id);
            record.TicketIds = ticketRecords.ToList().ConvertAll(_ => _.Id);

            return Ok(record);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var records = await _reservationRecordService.GetAllAsync();
            var reservations = records.ToList().ConvertAll(_mapper.Map<ReservationRecordBaseModel>);

            return Ok(reservations);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]ReservationModel model)
        {
            var record = _mapper.Map<ReservationRecord>(model);
            record.ReservationTime = DateTime.Now;

            var createdRecord = await _reservationRecordService.AddAsync(record);
            var createdTickets = await Task.WhenAll(model.TicketIds.ToList().ConvertAll(ticket =>
            {
                var reservationTicket = new ReservationTicket();

                reservationTicket.TicketId = ticket;
                reservationTicket.ReservationId = createdRecord.Id;
                reservationTicket.Reservation = createdRecord;

                return _reservationTicketService.AddAsync(reservationTicket);
            }));

            return Ok(createdRecord.Id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("payment/{reservationId}")]
        public async Task<IActionResult> PutPayment(Guid reservationId)
        {
            var reservation = await _reservationRecordService.GetAsync(reservationId);
            reservation.WasPaid = true;
            reservation.PaymentTime = DateTime.Now;

            var updatedReservation = await _reservationRecordService.UpdateAsync(reservationId, reservation);

            var record = _mapper.Map<ReservationRecordModel>(updatedReservation);
            var ticketRecords = await _reservationTicketService.Find(_ => _.ReservationId == record.Id);
            record.TicketIds = ticketRecords.ToList().ConvertAll(_ => _.Id);

            return Ok(record);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("cancelation/{reservationId}")]
        public async Task<IActionResult> PutCancelation(Guid reservationId)
        {
            var reservation = await _reservationRecordService.GetAsync(reservationId);
            reservation.WasCanceled = true;
            reservation.CancelationTime = DateTime.Now;

            var updatedReservation = await _reservationRecordService.UpdateAsync(reservationId, reservation);

            var record = _mapper.Map<ReservationRecordModel>(updatedReservation);
            var ticketRecords = await _reservationTicketService.Find(_ => _.ReservationId == record.Id);
            record.TicketIds = ticketRecords.ToList().ConvertAll(_ => _.Id);

            return Ok(record);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        [Route("{reservationId}")]
        public async Task<IActionResult> Delete(Guid reservationId)
        {
            await _reservationRecordService.RemoveAsync(reservationId);
            return NoContent();
        }
    }
}
