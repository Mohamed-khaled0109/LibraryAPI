namespace LibraryAPI.DTO
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<string> Books { get; set; } = new List<string>();

    }
}
