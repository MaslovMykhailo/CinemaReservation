using AutoMapper;
using CinemaReservation.Models;
using CinemaReservation.Persisted.Entities;

namespace CinemaReservation.Mapping
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<ReservationModel, ReservationRecord>().ReverseMap();
            CreateMap<ReservationRecordModel, ReservationRecord>().ReverseMap();
            CreateMap<ReservationRecordBaseModel, ReservationRecord>().ReverseMap();
        }
    }
}
