using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTO;
using FwCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FwApi.AppIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //api/Account/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));


                var token = new JwtSecurityToken(
                    issuer: "api/Account/login",
                    audience: "api/Account/login",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)

                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }

            return Unauthorized();

        }

        //api/Account/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "customer");

                    return Ok();
                }

            }

            // If we got this far, something failed, redisplay form
            return NoContent();
        }


    }//c
}//ns