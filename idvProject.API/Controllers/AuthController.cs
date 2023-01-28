using Azure.Core;
using idvProject.Business.Abstract;
using idvProject.Entities.Concrete;
using idvProject.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;

namespace idvProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AuthController(IConfiguration configuration, IUserService userService,IRoleService roleService, IUserRoleService userRoleService)
        {
            _configuration = configuration;
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDTO userDTO)
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = userDTO.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Mail = userDTO.Mail;
            _userService.UserAdd(user);
            Role role=_roleService.GetRole("user");
            _userRoleService.UserRoleAdd(new UserRole
            {
                RoleId = role.Id,
                UserId = user.Id,
                Roles = role,
                Users = user
            });

            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult<string> Login(UserDTO userDTO)
        {
            var user = _userService.GetByName(userDTO.UserName);
            if (user != null && user.Status == true)
            {
                List<UserRole> userWithRole = _userRoleService.GetByUserId(user.Id);
                if (user.UserName != userDTO.UserName)
                {
                    return BadRequest("User not found.");
                }

                if (!VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }

                string token = CreateToken(userWithRole);

                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(refreshToken);

                return Ok(token);
            }
            else
            {
                return BadRequest("Kullanıcı sistemde kayıtlı değildir!");
            }

        }

        //[HttpPost("refresh-token")]
        //public ActionResult<string> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];

        //    if (!user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token.");
        //    }
        //    else if (user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired.");
        //    }

        //    string token = CreateToken(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);

        //    return Ok(token);
        //}

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(List<UserRole> userRole)
        {
            List<Claim> claims = new List<Claim>();

            foreach (var role in userRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Roles.Name));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
