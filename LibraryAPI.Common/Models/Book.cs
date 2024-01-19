using System.ComponentModel.DataAnnotations;
using static LibraryAPI.Common.Enum;

namespace LibraryAPI.Common.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Author { get; set; } = string.Empty;
        public Category Category { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
    }
}
