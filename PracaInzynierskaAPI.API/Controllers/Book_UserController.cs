using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Book_User;
using PracaInzynierska.Application.Services.Book_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Book_UserController : ControllerBase
    {
        private readonly IBook_UserService _service;
        private ILogger _logger;

        public Book_UserController(IBook_UserService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetBooksByUser")]
        public async Task<IActionResult> GetBooksByUser(Guid userId)
        {
            try
            {
                var serviceResponse = _service.GetBooksByUser(userId);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_UserController.GetBooksByUser");
                throw;
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateBook_User")]
        public async Task<IActionResult> CreateBook_User(Book_UserDTO book_userDTO)
        {
            try
            {
                var serviceResponse = _service.AddBook_User(book_userDTO);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_UserController.GetBooksByUser");
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("DeleteBook_User")]
        public async Task<IActionResult> DeleteBook_User(Book_UserDTO book_userDTO)
        {
            try
            {
                var serviceResponse = _service.AddBook_User(book_userDTO);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_UserController.CreateBooksByUser");
                throw;
            }
        }
    }
}
