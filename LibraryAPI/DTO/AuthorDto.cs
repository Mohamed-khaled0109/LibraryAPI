namespace LibraryAPI.DTO
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public List<string> Books { get; set; } = new List<string>();
    }
}
