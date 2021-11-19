﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLog;
using PracaInzynierska.Application.DTO.User;
using PracaInzynierska.Application.Services.User;
using PracaInzynierskaAPI.API.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private ILogger _logger;

        public UserController(IUserService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUsers()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.GetAllUsers();
                    if (result.Success)
                        return await Task.FromResult(Ok(result));
                    else
                        return await Task.FromResult(BadRequest(result));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserController.GetAllUsers");
                    throw;
                }
                
            }
            return await Task.FromResult(BadRequest());    
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.UpdateUser(user);
                    if (result.Success)
                        return await Task.FromResult(Ok(result));
                    else
                        return await Task.FromResult(BadRequest(result));
                }
                catch (Exception err)
                {
                    _logger.Error(err, "UserController.GetAllUsers");
                    throw;
                }

            }
            return await Task.FromResult(BadRequest());
        }
    }
}