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
    public class UserStore: IUserStore<User>,
                            IUserRoleStore<User>

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

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
            => Context.AppUser
                .Where(x => x.AppUser_ID == Guid.Parse(userId))
                .Select(x => new User(x))
                .SingleAsync();

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName);
        
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
            => GetUserNameAsync(user, cancellationToken);

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
            => SetUserNameAsync(user, normalizedName, cancellationToken);

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => Context.AppUser.SingleOrDefaultAsync(
                    // TODO: fix this "TP\" bullshit
                    x => x.AppUser_Code == normalizedUserName || x.AppUser_Code == $"TP\\{normalizedUserName}",
                    cancellationToken)
                .ContinueWith((task) => task.Result == null ? null : new User(task.Result));

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)
                .Where(x => x.AppUser_ID == user.Id)
                .Select(x => x.Role.Role_Code)                
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<string>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);


        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)                
                .AnyAsync(x => x.AppUser_ID == user.Id && x.Role.Role_Code == roleName);                


        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            => Context.AppUser_to_Role
                .Include(x => x.Role)
                .Include(x => x.AppUser)
                .Where(x => x.Role.Role_Code == roleName)
                .Select(x => new User(x.AppUser))
                .ToListAsync(cancellationToken)
                .ContinueWith<IList<User>>(t => t.Result, TaskContinuationOptions.ExecuteSynchronously);

    }
}
