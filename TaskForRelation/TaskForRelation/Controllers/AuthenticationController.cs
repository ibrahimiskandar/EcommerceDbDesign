using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TaskForRelation.DTOs;
using TaskForRelation.Models;

namespace TaskForRelation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO requestModel)
        {
            CreatePasswordHash(requestModel.Password, out byte[] passwordSalt, out byte[] passwordHash);
            user.UserName = requestModel.UserName;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            return Ok(user);
        }
        public static void CreatePasswordHash(string password,out byte[] passwordSalt,out byte[] passwordHash)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
