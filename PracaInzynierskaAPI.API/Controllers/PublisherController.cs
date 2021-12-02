using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Publisher;
using PracaInzynierska.Application.Services.Publisher;
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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _service;
        private ILogger _logger;

        public PublisherController(IPublisherService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllPublishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            try
            {
                var controllerResponse = _service.GetAllPublishers();
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetAllAuthors");
                throw;
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("FindPublishersByName")]
        public async Task<IActionResult> FindPublishersByName(string name)
        {
            var list = new List<string>();
            list = name.Split(" ").ToList();
            try
            {
                var controllerResponse = _service.FindPublishersByName(list);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.FindPublishersByName");
                throw;
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetPublisherById")]
        public async Task<IActionResult> GetPublisherById(Guid id)
        {
            try
            {
                var controllerResponse = _service.GetPublisherById(id);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetPublisherById");
                throw;
            }
        }

        [Authorize(Policy = Policies.Publisher.Write)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreatePublisher")]
        public async Task<IActionResult> CreatePublisher(PublisherDTO publisher)
        {
            try
            {
                var controllerResponse = _service.AddPublisher(publisher);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.CreatePublisher");
                throw;
            }
        }

        [Authorize(Policy = Policies.Publisher.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdatePublisher")]
        public async Task<IActionResult> UpdatePublisher(PublisherDTO publisher)
        {
            try
            {
                var controllerResponse = _service.UpdatePublisher(publisher);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.UpdatePublisher");
                throw;
            }
        }

        [Authorize(Policy = Policies.Publisher.SoftDelete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("SoftDeletePublisher")]
        public async Task<IActionResult> SoftDeletePublisher(PublisherDTO publisher)
        {
            try
            {
                var controllerResponse = _service.SoftDeletePublisher(publisher);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.SoftDeletePublisher");
                throw;
            }
        }
    }
}
