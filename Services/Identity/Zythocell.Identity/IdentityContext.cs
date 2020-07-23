using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Identity
{
    public class IdentityContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        public IdentityContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=ZythocellIdentityDb.db;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
