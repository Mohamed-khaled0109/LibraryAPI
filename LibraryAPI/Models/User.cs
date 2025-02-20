using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Models
{
    public class User:IdentityUser
    {
        //public string Id {  get; set; }
        //-----------------------------
        public virtual ICollection<Review> reviews {  get; set; }
        public virtual ICollection<Reservation> reservations {  get; set; }
        public virtual ICollection<Payment> payments { get; set; }
    }
}
