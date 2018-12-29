using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartQA.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }
        public override string Name { get; set; }

        public Role(DB.Models.Auth.Role dbRole)
        {
            Id = dbRole.ID;
            Name = dbRole.Role_Code;
        }
    }
}
