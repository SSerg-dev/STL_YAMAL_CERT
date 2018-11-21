using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;

namespace SmartQA.Auth
{
    public class UserStore: IUserStore<ApplicationUser>,
                            IUserRoleStore<ApplicationUser>

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
            => Context.AppUser
                .Where(x => x.AppUser_ID == Guid.Parse(userId))
                .Select(x => new ApplicationUser(x))
                .SingleAsync();

        public Task<string> GetUserIdAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Task.FromResult(applicationUser.Id.ToString());

        public Task<string> GetUserNameAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Task.FromResult(applicationUser.UserName);
        
        public Task SetUserNameAsync(ApplicationUser applicationUser, string userName, CancellationToken cancellationToken)
        {
            applicationUser.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => GetUserNameAsync(applicationUser, cancellationToken);

        public Task SetNormalizedUserNameAsync(ApplicationUser applicationUser, string normalizedName, CancellationToken cancellationToken)
            => SetUserNameAsync(applicationUser, normalizedName, cancellationToken);

        public Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => Context.AppUser.SingleOrDefaultAsync(
                    // TODO: fix this "TP\" bullshit
                    x => x.AppUser_Code == normalizedUserName || x.AppUser_Code == $"TP\\{normalizedUserName}",
                    cancellationToken)
                .ContinueWith((task) => task.Result == null ? null : new ApplicationUser(task.Result));

        public Task AddToRoleAsync(ApplicationUser applicationUser, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ApplicationUser applicationUser, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser applicationUser, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)
                .Where(x => x.AppUser_ID == applicationUser.Id)
                .Select(x => x.Role.Role_Code)                
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<string>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);


        public Task<bool> IsInRoleAsync(ApplicationUser applicationUser, string roleName, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)                
                .AnyAsync(x => x.AppUser_ID == applicationUser.Id && x.Role.Role_Code == roleName);                


        public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)
                .Include(x => x.AppUser)
                .Where(x => x.Role.Role_Code == roleName)
                .Select(x => new ApplicationUser(x.AppUser))
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<ApplicationUser>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);

    }
}
