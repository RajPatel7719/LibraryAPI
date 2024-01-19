using LibraryAPI.Common.Models;

namespace DataAccessLayer.IRepositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks(int page, int pageSize);
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
