using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTO;
using FwCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FwApi.AppIdentity
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        // /register
        [Route("api/auth/register")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            if (await _userManager.FindByNameAsync(model.UserName) == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                return Ok(new { Username = user.UserName });
            }

            else return BadRequest( "User Name is already exist...");
            
            
        }

        [Route("api/auth/login")] // /login
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);
           


            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userId = user.Id;
                var users = _userManager.Users.ToList();

                var userWithRole = _context.UserRoles.ToList();

                var roles = _roleManager.Roles.ToList();


                var result= from u in users
                             join ur in userWithRole
                             on u.Id equals ur.UserId
                             join r in roles
                             on ur.RoleId equals r.Id
                             where u.Id == userId
                             select r.Name;
                
                
                             
                //var userRole =  _context.UserRoles.Where(x => x.UserId == userId);
                //var roleId = userRole.;
                //var role = await _roleManager.FindByIdAsync(roleId);
                //var roleName = role.Name;

                var claim = new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.Role,result.SingleOrDefault().ToString()),
                    new Claim(JwtRegisteredClaimNames.Typ,result.SingleOrDefault().ToString())

                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                  claims:claim
                );

                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                      
                  });
            }
            return Unauthorized();
        }

        // / Get profile
        [Route("api/auth/getProfile")]
        [HttpGet]
        public async Task<ActionResult> GetProfile(string name)
        {
            var user = await _userManager.FindByNameAsync(name.Trim());
            
            
            return Ok(user);

        }

        // / Update profile
        [Route("api/auth/updateProfile")]
        [HttpPut("{name}")]
        public async Task<ActionResult> updateProfile(string name,[FromBody] RegisterViewModel model)
        {
            var oldProfile = await _userManager.FindByNameAsync(name.Trim());
            oldProfile.FirstName = model.FirstName;
            oldProfile.LastName = model.LastName;
            oldProfile.Email = model.Email;
            oldProfile.UserName = model.UserName;

            if (oldProfile != null)
            {
                var Update = await _userManager.UpdateAsync(oldProfile);
                return Ok(model);
            }
            return NoContent();


        }




    }//c


}//ns