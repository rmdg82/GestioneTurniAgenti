using GestioneTurniAgenti.Server.Services;
using GestioneTurniAgenti.Shared.Dtos.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(UserManager<IdentityUser> userManager, IAuthenticationService authenticationService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            var user = await _userManager.FindByNameAsync(userForAuthenticationDto.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthenticationDto.Password))
            {
                return Unauthorized(new AuthenticationResponseDto
                {
                    ErrorMessage = "Autenticazione invalida",
                });
            }

            var token = await _authenticationService.GetToken(user);
            return Ok(new AuthenticationResponseDto
            {
                IsAuthSuccessful = true,
                Token = token
            });
        }
    }
}