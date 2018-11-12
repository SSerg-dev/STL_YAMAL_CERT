using Microsoft.AspNet.Identity;
using SmartQA1._1._2.DB.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SmartQA1._1._2.Authentication
{
    public class RoleStore : IRoleStore<Role, Guid>
    {
        private readonly LogAuthSchema Context;

        public RoleStore(LogAuthSchema context)
        {
            Context = context;
        }

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<Role> FindByIdAsync(Guid roleId)
        {
            return Context.Role.FindAsync(new object[] { roleId })
                 .ContinueWith((task) => new Role(task.Result));

        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            var dbRole = Context.Role
                .FirstOrDefault(x => x.Role_Code == roleName);
            return Task.FromResult(dbRole != null ? new Role(dbRole) : null);
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}