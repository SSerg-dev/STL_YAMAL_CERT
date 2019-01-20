using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;


namespace SmartQA.Auth
{
    public class UserStore : IUserStore<ApplicationUser>,
        IUserRoleStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>
    {
        private DataContext Context;

        public UserStore(DataContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
            => Context.Set<AppUser>()
                .Where(x => x.ID == Guid.Parse(userId))
                .Select(x => new ApplicationUser(x))
                .SingleAsync();

        public Task<string> GetUserIdAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Task.FromResult(applicationUser.Id.ToString());

        public Task<string> GetUserNameAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Task.FromResult(applicationUser.UserName);

        public Task SetUserNameAsync(ApplicationUser applicationUser, string userName,
            CancellationToken cancellationToken)
        {
            applicationUser.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser applicationUser,
            CancellationToken cancellationToken)
            => GetUserNameAsync(applicationUser, cancellationToken);

        public Task SetNormalizedUserNameAsync(ApplicationUser applicationUser, string normalizedName,
            CancellationToken cancellationToken)
            => SetUserNameAsync(applicationUser, normalizedName, cancellationToken);

        public Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Context.Set<AppUser>()
                .FindAsync(applicationUser.Id)
                .ContinueWith(task => applicationUser.Save(task.Result), cancellationToken)
                .ContinueWith(task => IdentityResult.Success, cancellationToken);

        public Task<IdentityResult> DeleteAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => Context.Set<AppUser>().SingleOrDefaultAsync(
                    // TODO: fix this "TP\" bullshit
                    x => x.AppUser_Code.ToUpper() == normalizedUserName.ToUpper() ||
                         x.AppUser_Code.ToUpper() == $"TP\\{normalizedUserName}".ToUpper(),
                    cancellationToken)
                .ContinueWith((task) => task.Result == null ? null : new ApplicationUser(task.Result));

        public Task AddToRoleAsync(ApplicationUser applicationUser, string roleName,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ApplicationUser applicationUser, string roleName,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Context.Set<AppUser_to_Role>()
                .Include(x => x.Role)
                .Where(x => x.AppUser_ID == applicationUser.Id)
                .Select(x => x.Role.Role_Code)
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<string>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);

        public Task<bool> IsInRoleAsync(ApplicationUser applicationUser, string roleName,
            CancellationToken cancellationToken)
            => Context.Set<AppUser_to_Role>()
                .Include(x => x.Role)
                .AnyAsync(x => x.AppUser_ID == applicationUser.Id && x.Role.Role_Code == roleName);

        public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            => Context.Set<AppUser_to_Role>()
                .Include(x => x.Role)
                .Include(x => x.AppUser)
                .Where(x => x.Role.Role_Code == roleName)
                .Select(x => new ApplicationUser(x.AppUser))
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<ApplicationUser>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}