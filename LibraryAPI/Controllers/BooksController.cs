using BusinessAccessLayer.IService;
using LibraryAPI.Common.ModelsDTO;
using LibraryAPI.Common.Result;
using Microsoft.AspNetCore.Mvc;
using static LibraryAPI.Common.Enum;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks(int page = 1, int pageSize = 10)
        {
            ResultPT result;
            try
            {
                var books = _bookService.GetBooks(page, pageSize);
                if (books != null && books.Any())
                {
                    result = new ResultPT
                    {
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Record Fetch Successfully.!",
                        Result = books
                    };
                    return Ok(result);
                }
                else
                {
                    result = new ResultPT
                    {
                        ResponseStatus = ResponseStatus.Error,
                        Message = "Books Not Found.!",
                        Result = books
                    };
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                result = new ResultPT
                {
                    ResponseStatus = ResponseStatus.Error,
                    Message = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            ResultPT result;
            try
            {
                var book = _bookService.GetBookById(id);

                if (book == null)
                {
                    result = new ResultPT
                    {
                        ResponseStatus = ResponseStatus.Error,
                        Message = "Book Not Found.!"
                    };
                    return NotFound(result);
                }

                result = new ResultPT
                {
                    ResponseStatus = ResponseStatus.Success,
                    Message = "Record Fetch Successfully.!",
                    Result = book
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = ex.Message };
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BookDTO bookDTO)
        {
            ResultPT result;
            try
            {
                if (bookDTO == null)
                {
                    result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = "Invalid Book Data" };
                    return BadRequest(result);
                }

                _bookService.CreateBook(bookDTO);
                result = new ResultPT { ResponseStatus = ResponseStatus.Success, Message = "Book Created Successfully.!", Result = bookDTO };

                return Ok(result);
            }
            catch (Exception ex)
            {
                result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = ex.Message };
                return StatusCode(500, result);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            ResultPT result;
            try
            {
                if (bookDTO == null)
                {
                    result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = "Invalid Book Data" };
                    return BadRequest(result);
                }

                _bookService.UpdateBook(id, bookDTO);
                result = new ResultPT { ResponseStatus = ResponseStatus.Success, Message = "Book Updated Successfully", Result = bookDTO };
                return Ok(result);
            }
            catch (Exception ex)
            {
                result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = ex.Message };
                return StatusCode(500, result);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            ResultPT result;
            try
            {
                _bookService.DeleteBook(id);
                result = new ResultPT { ResponseStatus = ResponseStatus.Success, Message = "Book Deleted Successfully.!" };
                return Ok(result);
            }
            catch (Exception ex)
            {
                result = new ResultPT { ResponseStatus = ResponseStatus.Error, Message = ex.Message };
                return StatusCode(500, result);
            }
        }
    }
}
