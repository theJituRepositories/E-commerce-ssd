using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TaskManagerConsole.Entities
{
    public  class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext() : base()
        {
        }
        //OnConfiguring() method is used to select and configure the data source

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=TaskManagerDB; Trusted_Connection=True; TrustServerCertificate=True");
            
        }
        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        // Add the domain classes on the Db
        public DbSet<Tasks> Tasks { get; set; }


    }
}
