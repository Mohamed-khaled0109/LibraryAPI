using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class Context:IdentityDbContext<User>
    {
        public DbSet<User> users { get; set; }
        public DbSet<Book> books {  get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Borrowing> borrowings {  get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Reservation> reservations {  get; set; }
        public DbSet<Review> reviews {  get; set; }
        public DbSet<UserBookDorrower> userBookDorrowers {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data source=MOHAMEDKHALED;Initial catalog=LibraryApi;Integrated security=true");
            // optionsBuilder.UseSqlServer($"Server=.;Database=Graduation;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);

        }


    }
}
