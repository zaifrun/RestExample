using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF_app_1
{
    internal class MyDbContext: DbContext
    {
        string conn = @"Data Source=D50219\SQLEXPRESS;Initial Catalog = blogrest;Connect Timeout = 30; Encrypt = False; TrustServerCertificate = true;Integrated Security=True";



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.LogTo(message => Debug.WriteLine(message));
           optionsBuilder.UseSqlServer(conn);
       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
