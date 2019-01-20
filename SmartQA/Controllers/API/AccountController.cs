using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using SmartQA.Models.Account;
using SmartQA.Util;


namespace SmartQA.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly AppUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public AccountController(
            AppUserManager userManager,
            DataContext context,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _context = context;
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
        public async Task<object> Login([FromBody] LoginViewModel model)
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

        /// <summary>
        /// Temporary fix to migrate old passwords to hashes. Remove this later.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> FixPasswords()
        {
            byte[] passKey =
            {
                0x32, 0x44, 0x65, 0x63,
                0x6C, 0x69, 0x6E, 0x65,
                0x34, 0x49, 0x6E, 0x63,
                0x6C, 0x69, 0x6E, 0x65
            };
            await _context.Set<AppUser>()
                .Where(x => x.PasswordHash == null && x.User_Password != null)
                .ForEachAsync(user =>
                {
                    var password = Encoding.UTF8.GetString(new Encryptor3DES(passKey).decrypt(user.User_Password));
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(new ApplicationUser(user), password);
                    user.User_Password = null;
                    _context.Update(user);
                })
                .ContinueWith(t => _context.SaveChangesAsync());

            return Ok("success");
        }

        [Authorize]
        [HttpPost]
        public async Task<object> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Get(User);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors
                });
            }

            await _context.SaveChangesAsync();

            return Ok();
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
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_appSettings.JwtExpireDays));

                var token = new JwtSecurityToken(
                    _appSettings.JwtIssuer,
                    _appSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: signingCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            });
        }
    }
}