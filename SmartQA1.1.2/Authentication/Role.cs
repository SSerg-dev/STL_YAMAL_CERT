using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.Authentication
{
    public class Role : IRole<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get ; set; }

        public Role(SmartQA1._1._2.DB.Logging.Role dbRole)
        {
            Id = dbRole.Role_ID;
            Name = dbRole.Role_Code;
        }
    }


}