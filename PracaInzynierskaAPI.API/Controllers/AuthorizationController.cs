using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.User;
using PracaInzynierska.Application.Services.User;
using PracaInzynierskaAPI.API.JWT;
using PracaInzynierskaAPI.API.JWT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _service;
        private IJwtService _tokenService;
        private ILogger _logger;
        private static IMapper _mapper;

        public AuthorizationController(IUserService service,
            IJwtService tokenService,
            IMapper mapper)
        {
            _tokenService = tokenService;
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
            _mapper = mapper;
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserModel login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isEmailExists = false;
                    bool isUserNameExist = false;
                    var checkingUserName = _service.GetUserByUserName(login.Login);
                    if (checkingUserName.Success)
                        isUserNameExist = true;

                    var checkingEmail = _service.GetUserByEmail(login.Login);
                    if (checkingEmail.Success)
                        isEmailExists = true;

                    if(isUserNameExist == false && isEmailExists == false )
                        return await Task.FromResult(BadRequest("błędny użytkownik lub hasło"));

                    var loginResponse = _service.Login(login.Login, login.Password);
                    
                    if (loginResponse.Success)
                    {
                        var token = await _tokenService.CreateToken(loginResponse.Object.Id);
                        return await Task.FromResult(Ok(token));
                    }
                    else
                        return await Task.FromResult(BadRequest());
                }
                catch (Exception err)
                {
                    _logger.Error(err, "AuthorizationColtroller.Login");
                    throw;
                }
            }
            return await Task.FromResult(BadRequest());
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var registerResponse = _service.AddUser(user);
                if (registerResponse.Success)
                    return await Task.FromResult(Ok($"Użytkownik {user.UserName} został utworzony"));
                else
                    return await Task.FromResult(BadRequest());
            }
            return await Task.FromResult(BadRequest());
        }



        public class LoginUserModel
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
