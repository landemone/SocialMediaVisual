using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IAspnetMembershipService _AspnetMembershipService;

        public TokenController(IConfiguration configuration, IAspnetMembershipService aspnetMembershipService)
        {
            _configuration = configuration;
            _AspnetMembershipService = aspnetMembershipService;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(LoginQueryFilter login)
        {
            var validation = await IsValidUser(login);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }

        private async Task<(bool, AspnetMembership)> IsValidUser(LoginQueryFilter login)
        {
            var user = await _AspnetMembershipService.GetLoginByCredentials(login);

            return (user != null, user);

        }

        private string GenerateToken(AspnetMembership aspnetMembership)
        {
            //header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Secretkey"]));

            var signingCredencials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredencials);

            //claims

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, aspnetMembership.User.ToString()),
                new Claim(ClaimTypes.Email, aspnetMembership.Email),
                new Claim(ClaimTypes.Role, aspnetMembership.UserId.ToString()),
            };
            var payload = new JwtPayload
            (
              _configuration["Authentication:Issuer"],
              _configuration["Authentication:Audience"],
              claims,
              DateTime.Now,
              DateTime.UtcNow.AddMinutes(10)

            );

            //sign

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
