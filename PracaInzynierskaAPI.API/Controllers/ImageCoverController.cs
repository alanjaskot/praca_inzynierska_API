using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.ImageCover;
using PracaInzynierska.Application.Services.ImageCover;
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
    public class ImageCoverController : ControllerBase
    {
        private readonly IImageCoverService _service;
        private ILogger _logger;

        public ImageCoverController(IImageCoverService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetImageCoverById")]
        public async Task<IActionResult> GetImageCoverById(Guid id)
        {
            try
            {
                var controllerResponse = _service.GetImageCoverById(id);
                if (controllerResponse.Success)
                    return await Task.FromResult(Ok(controllerResponse));
                else
                    return await Task.FromResult(BadRequest(controllerResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageControllerController.GetImageControllerById");
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateImageCover")]
        public async Task<IActionResult> CreateImageCover(ImageCoverDTO imageCover)
        {
            if (imageCover == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.AddImageCover(imageCover);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("okładka została dodana", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageControllerController.CreateImageCover");
                throw;
            }
        }

        [Authorize(Policy = Policies.ImageCover.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdateImageCover")]
        public async Task<IActionResult> UpdateImageCover(ImageCoverDTO imageCover)
        {
            if (imageCover == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.AddImageCover(imageCover);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageControllerController.UpdateImageCover");
                throw;
            }
        }

        [Authorize(Policy = Policies.ImageCover.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("DeleteImageCover")]
        public async Task<IActionResult> DeleteImageCover(ImageCoverDTO imageCover)
        {
            if (imageCover == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.AddImageCover(imageCover);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageControllerController.DeleteImageCover");
                throw;
            }
        }

    }
}
