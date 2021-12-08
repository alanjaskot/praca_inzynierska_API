using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Book;
using PracaInzynierska.Application.DTO.Book_Author;
using PracaInzynierska.Application.Services.Book;
using PracaInzynierska.Application.Services.Book_Author;
using PracaInzynierskaAPI.API.PoliciesAndPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IBook_AuthorService _baService;
        private static ILogger _logger;

        public BookController(IBookService serivce,
            IBook_AuthorService baService)
        {
            _service = serivce;
            _baService = baService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var serviceResponse = _service.GetAllBooks();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetAllBooks");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book.Approve)]
        [HttpGet("GetBooksToAprrove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksToAprrove()
        {            
            try
            {
                var serviceResponse = _service.GetBooksToApprove();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksToAprrove");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBooksByList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksByList(List<Guid> list)
        {
            try
            {
                var serviceResponse = _service.GetBooksByList(list);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByList");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBooksByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksByCategory(Guid categoryId)
        {
            try
            {
                var serviceResponse = _service.GetBooksByCategory(categoryId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByList");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBooksByPublisher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksByPublisher(Guid publisherId)
        {
            try
            {
                var serviceResponse = _service.GetBooksByPublisher(publisherId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByList");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetHighlithed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetHighlithed()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek == DayOfWeek.Monday || now.DayOfWeek == DayOfWeek.Thursday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                try
                {
                    var serviceResponse = _service.GetHighlightedBooksByMonth();
                    if (serviceResponse.Success)
                        return await Task.FromResult(Ok(serviceResponse));
                    else
                        return await Task.FromResult(BadRequest(serviceResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "BookService.GetHighlithedByMonth");
                    throw;
                }
            }
            if (now.DayOfWeek == DayOfWeek.Tuesday || now.DayOfWeek == DayOfWeek.Friday)
            {
                try
                {
                    var serviceResponse = _service.GetHighlightedBooksByYear();
                    if (serviceResponse.Success)
                        return await Task.FromResult(Ok(serviceResponse));
                    else
                        return await Task.FromResult(BadRequest(serviceResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "BookService.GetHighlithedByYear");
                    throw;
                }
            }

            else
            {
                try
                {
                    var serviceResponse = _service.GetHighlightedBooks();
                    if (serviceResponse.Success)
                        return await Task.FromResult(Ok(serviceResponse));
                    else
                        return await Task.FromResult(BadRequest(serviceResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "GetHighlithed");
                    throw;
                }
            }

        }

        [AllowAnonymous]
        [HttpGet("FindByBooksName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindByBooksName(string name)
        {
            List<string> list = new List<string>();
            list.AddRange(name.Split(" "));
            try
            {
                var serviceResponse = _service.FindBooksByName(list);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.FindBooksByName");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var serviceResponse = _service.GetBookById(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetById");
                throw;
            }
        }

        [HttpPost("CreateBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateBook(AddDeleteBook adBook)
        {
            if (adBook.Book == null || adBook.Book_Authors == null)
                return await Task.FromResult(BadRequest());
            
            adBook.Book.Id = Guid.NewGuid();
            foreach (var item in adBook.Book_Authors)
            {
                item.Id = Guid.NewGuid();
                item.BookId = adBook.Book.Id;
            }                

            try
            {
                var serviceResponse = _service.AddBook(adBook.Book);
                if (serviceResponse.Success)
                {
                    var baServiceRespone = _baService.AddBook_Authors(adBook.Book_Authors);
                    if (baServiceRespone.Success)
                        return await Task.FromResult(Created("Książka została dodana", adBook.Book.Id));
                    else
                        return await Task.FromResult(BadRequest(serviceResponse));
                }
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookController.CreateBook");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book.Approve)]
        [HttpPut("ApproveBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ApproveBooks(List<BookDTO> books)
        {
            if (books == null)
                return await Task.FromResult(BadRequest());

            try
            {
                var serviceResponse = _service.ApproveBooks(books);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookController.ApproveBooks");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book.Update)]
        [HttpPut("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateBook(BookDTO book)
        {
            if (book == null)
                return await Task.FromResult(BadRequest());

            try
            {
                var serviceResponse = _service.UpdateBook(book);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookController.UpdateBook");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book.SoftDelete)]
        [HttpDelete("SoftDeleteBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SoftDeleteBooks(List<BookDTO> books)
        {
            if (books == null)
                return await Task.FromResult(BadRequest());

            try
            {
                foreach (var book in books)
                {
                    var baServiceResponse = _baService.DeleteBook_Author(book.Id);
                    if (!baServiceResponse.Success)
                        return await Task.FromResult(BadRequest("Wystąpił błąd w trakcie usuwania"));
                }
                var serviceResponse = _service.SoftDeleteBooks(books);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookController.SoftDeleteBooks");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book.Delete)]
        [HttpDelete("DeleteBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            if (bookId == Guid.Empty)
                return await Task.FromResult(BadRequest("Wprowadzony identyfikator jest pusty"));

            try
            {
                var baServiceResponse = _baService.DeleteBook_Author(bookId);
                if (!baServiceResponse.Success)
                    return await Task.FromResult(BadRequest("Wystąpił błąd w trakcie usuwania"));

                var serviceResponse = _service.DeleteBook(bookId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookController.DeleteBook");
                throw;
            }
        }

        public class AddDeleteBook
        {
            public BookDTO Book { get; set; }
            public List<Book_AuthorDTO> Book_Authors { get; set; }
        }
    }
}
