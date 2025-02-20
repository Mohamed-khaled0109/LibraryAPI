using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.VisualBasic;

namespace LibraryAPI.Services
{
    public class ReservationRepo: IReservationRepo
    {
        private readonly Context context;

        public ReservationRepo(Context context)
        {
            this.context = context;
        }

        public List<Reservation> GetAll()
        {
            return context.reservations.ToList();
        }

        public ReservationDto GetById(int id)
        {
            var reservation=context.reservations.FirstOrDefault(r => r.Id == id);
            var reservationDto = new ReservationDto();

            reservationDto.ReservationDate = reservation.ReservationDate;
            reservationDto.UserId= reservation.UserId;
            reservationDto.BookId= reservation.BookId;
   
            return reservationDto;

        }

        public int create(ReservationDto reservationDto)
        {
            var reservation = new Reservation();

            reservation.ReservationDate = reservationDto.ReservationDate;
            reservation.UserId = reservationDto.UserId;
            reservation.BookId = reservationDto.BookId;

            context.reservations.Add(reservation);
            return context.SaveChanges();

        }

        public ReservationDto update(int id,ReservationDto reservationDto)
        {
            var reservation =context.reservations.FirstOrDefault(r => r.Id == id);

            reservation.ReservationDate = reservationDto.ReservationDate;
            reservation.UserId = reservationDto.UserId;
            reservation.BookId = reservationDto.BookId;

            context.SaveChanges();
            return reservationDto;
        }

        public int delete(int id)
        {
            var reservation= context.reservations.FirstOrDefault(r => r.Id == id);
            context.reservations.Remove(reservation);
            return context.SaveChanges();
        }
    }
}
