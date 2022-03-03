using System;
using Microsoft.EntityFrameworkCore;

namespace TDD_Sample_dotNet.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=./Demo.db");

    }
}
