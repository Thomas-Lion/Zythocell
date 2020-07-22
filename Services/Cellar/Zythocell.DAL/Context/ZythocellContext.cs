using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Context
{
    public class ZythocellContext : DbContext
    {
        public ZythocellContext() { }

        public ZythocellContext(DbContextOptions<ZythocellContext> options) : base(options)
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
                optionsBuilder.UseSqlite(@"Data Source=ZythocellCellarDb.db;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BeverageEF> Beverages { get; set; }
        public DbSet<CellarEF> Cellars { get; set; }
        public DbSet<RateEF> Rates { get; set; }
    }
}
