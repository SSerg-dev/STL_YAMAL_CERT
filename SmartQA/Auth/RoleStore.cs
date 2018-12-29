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
    public class RoleStore : IRoleStore<Role>
    {
        private DataContext Context;

        public RoleStore(DataContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);       

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
            => GetRoleNameAsync(role, cancellationToken);

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
            => SetRoleNameAsync(role, normalizedName, cancellationToken);

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
            => Context.Role
                .Where(x => x.ID == Guid.Parse(roleId))
                .Select(x => new Role(x))
                .SingleAsync();

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
            => Context.Role
                .Where(x => x.Role_Code == normalizedRoleName)
                .Select(x => new Role(x))
                .SingleAsync();

    }
}
