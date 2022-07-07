using JWT.Business.Contracts;
using JWT.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IConfiguration _configuration;

        public UserManagementController(IUserManagementService userManagementService, IConfiguration configuration)
        {
            _userManagementService = userManagementService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet()]
        public ActionResult GetEmployeesTest()
        {
            var employees = _userManagementService.GetEmployees();
            return Ok(employees);
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginVM userLogin)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", "1"),
                new Claim("DisplayName", "David"),
                new Claim("UserName", "cruz"),
                new Claim("Email", "cruz@abs"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
