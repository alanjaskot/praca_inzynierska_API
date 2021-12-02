using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.UserPermission;
using PracaInzynierska.Application.Services.UserPermission;
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
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _service;
        private ILogger _logger;

        public UserPermissionController(IUserPermissionService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [Authorize(Policy = Policies.UserPermission.Write)]
        [HttpPost("AddPermission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPermissions([FromBody]List<UserPermissionDTO> permissions)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var controllerResponse = _service.AddPermissionsByUserGuid(permissions);
                    if (controllerResponse.Success)
                        return await Task.FromResult(Ok(controllerResponse));
                    else
                        return await Task.FromResult(BadRequest(controllerResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserPermissionController.AddPermissions");
                    throw;
                }
            }
            else
                return await Task.FromResult(BadRequest());
        }

        [HttpGet("GetAllPermissionsForUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPermissionsForUser(Guid userId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var controllerResponse = _service.GetAllPermissionsByUserGuid(userId);
                    if (controllerResponse.Success)
                        return await Task.FromResult(Ok(controllerResponse));
                    else
                        return await Task.FromResult(BadRequest(controllerResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserPermissionController.AddPermissions");
                    throw;
                }
            }
            else
                return await Task.FromResult(BadRequest());
        }

        [HttpGet("GetPermitionByUserGuidAndPermission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPermitionByUserGuidAndPermission(Guid userId, string permissionName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var controllerResponse = _service.GetPermitionByUserGuidAndPermission(userId, permissionName);
                    if (controllerResponse.Success)
                        return await Task.FromResult(Ok(controllerResponse));
                    else
                        return await Task.FromResult(BadRequest(controllerResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserPermissionController.AddPermissions");
                    throw;
                }
            }
            else
                return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.UserPermission.Delete)]
        [HttpDelete("DeleteAllPermissionsByUserGuid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAllPermissionsByUserGuid([FromBody] List<UserPermissionDTO> permissions)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var controllerResponse = _service.DeleteAllPermissionsByUserGuid(permissions);
                    if (controllerResponse.Success)
                        return await Task.FromResult(Ok(controllerResponse));
                    else
                        return await Task.FromResult(BadRequest(controllerResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserPermissionController.DeleteAllPermissionsByUserGuid");
                    throw;
                }
            }
            else
                return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.UserPermission.Delete)]
        [HttpDelete("DeletePermitionForUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePermitionForUser(Guid userId, string permissionName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var controllerResponse = _service.DeletePermitionForUser(userId, permissionName);
                    if (controllerResponse.Success)
                        return await Task.FromResult(Ok(controllerResponse));
                    else
                        return await Task.FromResult(BadRequest(controllerResponse));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserPermissionController.DeletePermitionForUser");
                    throw;
                }
            }
            else
                return await Task.FromResult(BadRequest());
        }
    }
}
