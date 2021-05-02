using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.Business.Tools.JWTTools;
using MFC.Blog.DTO.DTOs.AppUserDtos;

namespace MFC.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUser(appUserLoginDto);
            if (user != null)
            {
                var token =_jwtService.GenerateJwt(user);
                return Created("", token);

            }
            else
            {
                return BadRequest("kullanıcı adı ve şifre hatalı");
            }

        }
    }
}
