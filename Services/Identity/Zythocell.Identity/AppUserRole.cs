using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Identity
{
    public class AppUserRole : IdentityRole<Guid>
    {
        public AppUserRole()
        {
        }

        public AppUserRole(string roleName) : base(roleName)
        {
        }
    }
}
