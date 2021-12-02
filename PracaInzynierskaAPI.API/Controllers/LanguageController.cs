using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Language;
using PracaInzynierska.Application.Services.Language;
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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _service;
        private ILogger _logger;

        public LanguageController(ILanguageService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllLanguages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllLanguages()
        {
            try
            {
                var serviceResponse = _service.GetAllLanguages();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageController.GetAllLanguages");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetLanguagesByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLanguagesByName(string name)
        {
            try
            {
                var serviceResponse = _service.GetLanguageByName(name);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetLanguagesByName");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("GetLanguageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLanguageById(Guid id)
        {
            try
            {
                var serviceResponse = _service.GetLanguageById(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.GetLanguageById");
                throw;
            }
        }

        [Authorize(Policy = Policies.Language.Write)]
        [HttpPost("CreateLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLanguage(LanguageDTO language)
        {
            if (language == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.AddLanguage(language);
                if (serviceResponse.Success)
                    return await Task.FromResult(Created("Język został dodany", serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.CreateLanguage");
                throw;
            }
        }

        [Authorize(Policy = Policies.Language.Update)]
        [HttpPut("UpdateLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLanguage(LanguageDTO language)
        {
            if (language == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.UpdateLanguage(language);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.UpdateLanguage");
                throw;
            }
        }

        [Authorize(Policy = Policies.Language.SoftDelete)]
        [HttpDelete("SoftDeleteLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SoftDeleteLanguage(LanguageDTO language)
        {
            if (language == null)
                return await Task.FromResult(BadRequest());
            try
            {
                var serviceResponse = _service.SoftDeleteLanguage(language);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse.Object));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorController.SoftDeleteLanguage");
                throw;
            }
        }
    }
}
