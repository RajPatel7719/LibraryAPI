using static LibraryAPI.Common.Enum;

namespace LibraryAPI.Common.ModelsDTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
    }
}
