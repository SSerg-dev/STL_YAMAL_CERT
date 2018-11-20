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
        public List<string> Roles { get; set; }

        public UserInfo(User user)
        {
            ID = user.Id;
            UserName = user.UserName;            
        }
    }


}
