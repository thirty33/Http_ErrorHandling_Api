using GlobalHttp_ErrorHandling_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>().ToTable("Project");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Project>().Property(p => p.creation_data).IsRequired();
            builder.Entity<Project>().Property(p => p.description).IsRequired().HasMaxLength(100);

        }
    }
}
