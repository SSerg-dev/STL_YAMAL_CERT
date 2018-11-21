using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.Auth;

namespace SmartQA.Models.Account
{
    public class UserInfo
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }

        public UserInfo(ApplicationUser applicationUser, IList<string> roles)
        {
            ID = applicationUser.Id;
            UserName = applicationUser.UserName;
            Roles = roles;
        }
    }


}
