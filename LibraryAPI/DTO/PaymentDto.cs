using LibraryAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.DTO
{
    public class PaymentDto
    {
        public bool State { get; set; }
        public double amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}
