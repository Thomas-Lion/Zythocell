using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
        }

        public AppUser(string userName) : base(userName)
        {
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
