using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using datingapp_service.datingapp.dtos;
using datingapp_service.datingapp.InterfaceRepository;
using datingapp_service.datingapp.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace datingapp_service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _irepo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository irepo, IConfiguration config)
        {
            _irepo = irepo;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        { 
            userRegisterDTO.UserName = userRegisterDTO.UserName.ToLower();
            if (_irepo.UserExists(userRegisterDTO.UserName))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                UserName = userRegisterDTO.UserName
            };

            var createdUser = _irepo.Register(userToCreate, userRegisterDTO.PassWord);

            return StatusCode(201);
        }


        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDto)
        {
            var userFromrepo = _irepo.Login(userLoginDto.UserName.ToLower(), userLoginDto.PassWord);
            if (userFromrepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromrepo.user_id.ToString()),
                new Claim(ClaimTypes.Name,userFromrepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenhendler = new JwtSecurityTokenHandler();
            var token = tokenhendler.CreateToken(tokenDescriptor);

            return Ok(new { 
                token = tokenhendler.WriteToken(token)
            });
        }
    }
}
