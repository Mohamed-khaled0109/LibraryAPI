using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string BookPass {  get; set; }
        public double prise {  get; set; }
        public bool IsAvailable { get; set; }
        public string imagUrl {  get; set; }
        public string language { get; set; }
        public string publisher { get; set; }
        //-------------------------------
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category category { get; set; }
        [ForeignKey("author")]
        public int authorId {  get; set; }
        public Author author { get; set; }

    }
}
