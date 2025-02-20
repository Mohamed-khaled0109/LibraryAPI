using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryAPI.DTO
{
    public class UserBookDorrowerDto
    {
        public string UserId {  get; set; }
        public int BookId {  get; set; }
        public List<string> borrowingsIdes { get; set; } = new List<string>(); 

    }
}
