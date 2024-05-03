using AutoService.Application.UseCases.AuthServices;
using AutoService.Domain.Entities.DTOs;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;
        public AuthController(UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistorDTO register)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }


            var user = new User()
            {
                Email = register.Email,
                FirstName = register.Firstname,
                LastName = register.Lastname,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                throw new Exception();

            return Ok(new ResponceModel()
            {
                IsSuccess = true,
                Message = "Muvaffaqiyatli yaratildi",
                StatusCode = 201
            });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Email Not found",
                    isSuccess = false,
                    Token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Password not match",
                    isSuccess = false,
                    Token = ""
                });
            }

            var token = _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                isSuccess = true,
                Message = "Success"
            });

        }
    }
}
