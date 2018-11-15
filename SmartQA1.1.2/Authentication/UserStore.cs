using Microsoft.AspNet.Identity;
using SmartQA1._1._2.DB.Logging;
using SmartQA1._1._2.DB.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SmartQA1._1._2.Authentication
{
    public class UserStore : IUserStore<User, Guid>,
                             IUserRoleStore<User, Guid>,
                             IUserLockoutStore<User, Guid>
    {
        private readonly LogAuthSchema Context;

        public UserStore(LogAuthSchema context)
        {
            Context = context;
        }

        public Task AddToRoleAsync(User user, string roleName) => throw new NotImplementedException();

        public Task CreateAsync(User user) => throw new NotImplementedException();

        public Task DeleteAsync(User user) => throw new NotImplementedException();

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<User> FindByIdAsync(Guid userId)
            => Context.AppUser.FindAsync(new object[] { userId })
                .ContinueWith((task) => new User(task.Result));

        public Task<User> FindByNameAsync(string userName)
        {
            var dbUser = Context.AppUser
                            .FirstOrDefault(x => x.AppUser_Code == userName || x.AppUser_Code == @"TP\" + userName);

            return Task.FromResult(dbUser != null ? new User(dbUser) : null);
        }


        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            var result = new UserGetResult<MsgIdPair>(user.Id);
            var spa = new StoredProcedureAdapter(Context);

            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    spa.ExecuteStoredProcedure(
                        result,
                        "dbo",
                        "User_FormType_Get",
                        user.Id
                    );
                    // ShortName = result.ShortName;
                    // Division_ID = result.Division_ID;
                    // Division_Name = result.Division_Name;
                    var RoleCode = result.Role_Code;

                    transaction.Commit();

                    return Task.FromResult(new List<string>() { RoleCode } as IList<string>);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
            => GetRolesAsync(user)
            .ContinueWith((task) => task.Result.Contains(roleName));

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user) => throw new NotImplementedException();

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTime lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user) => Task.FromResult(0);

        public Task<bool> GetLockoutEnabledAsync(User user) => Task.FromResult(false);

        public Task<DateTime> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }


    }
}