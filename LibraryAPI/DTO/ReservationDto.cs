namespace LibraryAPI.DTO
{
    public class ReservationDto
    {
        public DateTime ReservationDate { get; set; }

        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}
