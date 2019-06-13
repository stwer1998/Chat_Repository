using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class MyDbContext : DbContext
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ChatDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public MyDbContext() : base()
        { Database.EnsureCreated(); }

        public DbSet<User> User { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

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
