﻿using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.Auths.Commands.Login;
using Kodlama.Io.Devs.Application.Features.Auths.Commands.Register;
using Kodlama.Io.Devs.Application.Features.Auths.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };
            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var loginCommand = new LoginCommand
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };

            var result = await Mediator!.Send(loginCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }


        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true ,Expires=DateTime.Now.AddDays(7)};
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
