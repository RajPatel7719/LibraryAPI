using LibraryAPI.Common.Models;
using LibraryAPI.Common.ModelsDTO;

namespace BusinessAccessLayer.IService
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks(int page, int pageSize);
        BookDTO GetBookById(int id);
        void CreateBook(BookDTO book);
        void UpdateBook(int id, BookDTO book);
        void DeleteBook(int id);
    }
}
