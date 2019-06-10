using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class MyDbContext : DbContext
    {
        const string connectionString = "Server=MACHINE-UBDDM1S;Database=ChatDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public MyDbContext() : base()
        { Database.EnsureCreated(); }

        public DbSet<User> User { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Rights> Rights { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
