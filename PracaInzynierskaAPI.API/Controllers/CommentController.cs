using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Comment;
using PracaInzynierska.Application.Services.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        private ILogger _logger;

        public CommentController(ICommentService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllCommentsForBook")]
        public async Task<IActionResult> GetAllCommentsForBook(Guid bookId)
        {
            try
            {
                var controllerResponse = _service.GetAllCommentsByBook(bookId);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentController.GetAllCommentsForBook");
                throw;
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllCommentsByUser")]
        public async Task<IActionResult> GetAllCommentsByUser(Guid userId)
        {
            try
            {
                var controllerResponse = _service.GetAllCommentsByUser(userId);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentController.GetAllCommentsByUser");
                throw;
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllCommentsByComment")]
        public async Task<IActionResult> GetAllCommentsByComment(Guid commentId)
        {
            try
            {
                var controllerResponse = _service.GetAllCommentsByComment(commentId);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentController.GetAllCommentsByBook");
                throw;
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetCommentById")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            try
            {
                var controllerResponse = _service.GetCommentById(id);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentController.GetCommentById");
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentDTO comment)
        {
            if (comment == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.AddComment(comment);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("komentarz został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.CreateAuthor");
                throw;
            }
        }

        [Authorize(Policy = Policies.Comment.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(CommentDTO comment)
        {
            if (comment == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.UpdateComment(comment);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.UpdateAuthor");
                throw;
            }
        }

        [Authorize(Policy = Policies.Comment.SoftDelete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("SoftDeleteComment")]
        public async Task<IActionResult> SoftDeleteComment(CommentDTO comment)
        {
            if (comment == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.UpdateComment(comment);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
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
