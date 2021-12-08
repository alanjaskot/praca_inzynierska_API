using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Book_Author;
using PracaInzynierska.Application.Services.Book_Author;
using PracaInzynierskaAPI.API.PoliciesAndPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Book_AuthorController : ControllerBase
    {
        private readonly IBook_AuthorService _service;
        private ILogger _logger;

        public Book_AuthorController(IBook_AuthorService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllBooksByAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBooksByAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
                return await Task.FromResult(BadRequest("Wprowadzony identyfikator jest pusty"));
            try
            {
                var serviceResponse = _service.GetAllBooksByAuthor(authorId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorsController.GetAllBooksByAuthor");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAllAuthorsByBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAuthorsByBook(Guid bookId)
        {
            if (bookId == Guid.Empty)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.GetAllBooksByAuthor(bookId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorsController.GetAllAuthorsByBook");
                throw;
            }
        }

        [Authorize(Policy = Policies.Book_Author.Delete)]
        [HttpDelete("GetAllAuthorsByBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBook_Author(Guid id)
        {
            if (id == Guid.Empty)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.DeleteBook_Author(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorsController.DeleteBook_Author");
                throw;
            }
        }
    }
}
