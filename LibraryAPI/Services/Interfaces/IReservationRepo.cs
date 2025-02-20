using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IReservationRepo
    {
        public List<Reservation> GetAll();
        public ReservationDto GetById(int id);
        public int create(ReservationDto reservationDto);
        public ReservationDto update(int id, ReservationDto reservationDto);
        public int delete(int id);
    }
}
