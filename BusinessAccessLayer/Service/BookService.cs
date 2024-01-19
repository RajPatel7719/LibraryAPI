using BusinessAccessLayer.IService;
using DataAccessLayer.IRepositories;
using LibraryAPI.Common.Models;
using LibraryAPI.Common.ModelsDTO;

namespace BusinessAccessLayer.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookDTO GetBookById(int id)
        {
            try
            {
                var book = _bookRepository.GetBookById(id);
                return MapToDto(book);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving book by ID", ex);
            }
        }

        public IEnumerable<BookDTO> GetBooks(int page, int pageSize)
        {
            try
            {
                var books = _bookRepository.GetBooks(page, pageSize);
                return books.Select(book => MapToDto(book));
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving books", ex);
            }
        }

        public void CreateBook(BookDTO bookDTO)
        {
            try
            {
                var book = MapToModel(bookDTO);
                _bookRepository.AddBook(book);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating book", ex);
            }
        }

        public void UpdateBook(int id, BookDTO book)
        {
            try
            {
                var existingBook = _bookRepository.GetBookById(id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.Category = book.Category;
                    existingBook.Price = book.Price;
                    existingBook.ISBN = book.ISBN;
                    existingBook.PublicationDate = book.PublicationDate;

                    _bookRepository.UpdateBook(existingBook);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book", ex);
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book", ex);
            }
        }


        #region Private Methods

        private static BookDTO MapToDto(Book book) => new()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Category = book.Category,
            Price = book.Price,
            ISBN = book.ISBN,
            PublicationDate = book.PublicationDate
        };

        private static Book MapToModel(BookDTO bookDto) => new()
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            Category = bookDto.Category,
            Price = bookDto.Price,
            ISBN = bookDto.ISBN,
            PublicationDate = bookDto.PublicationDate
        };

        #endregion
    }
}
