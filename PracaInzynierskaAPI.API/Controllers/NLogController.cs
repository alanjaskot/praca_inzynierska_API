using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.Services.NLog;
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
    public class NLogController : ControllerBase
    {
        private readonly INLogService _service;
        private ILogger _logger;

        public NLogController(INLogService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [Authorize(Policy = Policies.NLogs.Read)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllNLogs")]
        public async Task<IActionResult> GetAllNLogs()
        {
            try
            {
                var controllerResponse = _service.GetAllNLogs();
                if (controllerResponse != null)
                    return await Task.FromResult(Ok());
                else
                    return await Task.FromResult(BadRequest());
            }
            catch (Exception err)
            {
                _logger.Error(err, "NLogsController.GetAllNLogs");
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetNLogsByDateTimeRange")]
        public async Task<IActionResult> GetNLogsByDateTimeRange(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            try
            {
                var controllerResponse = _service.GetNLogsByDateTimeRange(dateTimeFrom, dateTimeTo);
                if (controllerResponse != null)
                    return await Task.FromResult(Ok());
                else
                    return await Task.FromResult(BadRequest());
            }
            catch (Exception err)
            {
                _logger.Error(err, "NLogsController.GetNLogsByDateTimeRange");
                throw;
            }
        }
    }
}
