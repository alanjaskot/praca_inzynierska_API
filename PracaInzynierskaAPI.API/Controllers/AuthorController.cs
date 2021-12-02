using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Author;
using PracaInzynierska.Application.Services.Author;
using PracaInzynierskaAPI.API.PoliciesAndPermissions;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private ILogger _logger;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<AuthorDTO>>>> GetAllAuthors()
        {
            try
            {
                var serviceResponse = _authorService.GetAllAuthors();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetAllAuthors");
                throw;
            }
        }

        [Authorize(Policy = Policies.Author.Approve)]
        [HttpGet("GetAuthorsToApprove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<List<AuthorDTO>>>> GetAuthorsToApprove()
        {
            try
            {
                var serviceResponse = _authorService.GetAllAuthors();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetAuthorsToApprove");
            }
            return await Task.FromResult(BadRequest());
        }

        [AllowAnonymous]
        [HttpGet("FindAuthorsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<AuthorDTO>>>> FindAuthorsByName(string name)
        {
            var list = default(List<string>);
            list.AddRange(name.Split(" "));
            try
            {
                var serviceResponse = _authorService.FindAuthorsByName(list);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.FindByName");
            }
            return await Task.FromResult(BadRequest());
        }

        [AllowAnonymous]
        [HttpGet("GetAuthorsByIds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<AuthorDTO>>>> GetAuthorsByIds(List<Guid> list)
        {
            try
            {
                var serviceResponse = _authorService.GetAuthorsByIds(list);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetAuthorsBy");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<AuthorDTO>>> GetAuthorById(Guid id)
        {
            if (id == Guid.Empty)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _authorService.GetAuthorById(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetAuthorById");
                throw;
            }
        }

        [HttpPost("CreateAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateAuthor(AuthorDTO author)
        {
            if (author == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _authorService.AddAuthor(author);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("Autor został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.CreateAuthor");
                throw;
            }
        }

        [Authorize(Policy = Policies.Author.Approve)]
        [HttpPut("ApproveAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ApproveAuthor(AuthorDTO author)
        {
            if (author == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _authorService.ApproveAuthor(author);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.ApproveAuthor");
                throw;
            }
        }

        [Authorize(Policy = Policies.Author.Update)]
        [HttpPut("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateAuthor(AuthorDTO author)
        {
            if (author == null)
                return await Task.FromResult(BadRequest("Wprowadzony autor jest pusty"));
            try
            {
                var serviceResponse = _authorService.UpdateAuthor(author);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("Autor został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.UpdateAuthor");
                throw;
            }
        }

        [Authorize(Policy = Policies.Author.SoftDelete)]
        [HttpDelete("SoftDeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SoftDeleteAuthor(List<AuthorDTO> authors)
        {
            if (authors == null)
                return await Task.FromResult(BadRequest("Nie wprowadzono autora do usunięcia"));
            try
            {
                var serviceResponse = _authorService.SoftDeleteAuthors(authors);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("Autor został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.SoftDeleteAuthors");
                throw;
            }
        }

        [Authorize(Policy = Policies.Author.Delete)]
        [HttpDelete("DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            if (id == Guid.Empty)
                return await Task.FromResult(BadRequest("Nie wprowadzono autora do usunięcia"));
            try
            {
                var serviceResponse = _authorService.DeleteAuthor(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("Autor został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.DeleteAuthor");
                throw;
            }
        }
    }
}
