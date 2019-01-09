using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartQA.Auth;
using SmartQA.Models.Account;


namespace SmartQA.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class AccountController : Controller
    {

        private readonly AppUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;

        public AccountController(AppUserManager userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<object> UserInfo()
        {                        
            var user = await _userManager.Get(User);
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new UserInfo(user, roles));
        }

        [HttpPost]
        public async Task<object> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (result.Succeeded)
            {
               
                var appUser = await _userManager.FindByNameAsync(model.UserName);
                var roles = await _userManager.GetRolesAsync(appUser);

                return await GenerateJwtToken(appUser)
                    .ContinueWith(tokenTask =>
                        Ok(new LoginInfo()
                        {
                            Token = tokenTask.Result,
                            UserInfo = new UserInfo(appUser, roles)                            
                        })
                    );
            }
            
            return Unauthorized();            
        }

        private async Task<string> GenerateJwtToken(ApplicationUser applicationUser)
        {
            return await Task.Run(() =>
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_appSettings.JwtExpireDays));

                var token = new JwtSecurityToken(
                    _appSettings.JwtIssuer,
                    _appSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            });
            
        }
    }
}
