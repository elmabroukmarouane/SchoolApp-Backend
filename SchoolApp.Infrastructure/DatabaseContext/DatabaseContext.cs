using Microsoft.EntityFrameworkCore;
using SchoolApp.Infrastructure.Models.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SchoolApp.Infrastructure.DatabaseContext;
public class DatabaseContext : DbContext
    {
        public DbSet<Course>? courses { get; set; }
        public DbSet<Level>? levels { get; set; }
        public DbSet<Person>? persons { get; set; }
        public DbSet<Role>? roles { get; set; }
        public DbSet<User>? users { get; set; }
        public DbSet<Professor>? professors { get; set; }
        public DbSet<Student>? students { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }