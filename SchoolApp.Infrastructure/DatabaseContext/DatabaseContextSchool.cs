using Microsoft.EntityFrameworkCore;
using SchoolApp.Infrastructure.Models.Classes;
using System.Reflection;

namespace SchoolApp.Infrastructure.DatabaseContext;
public class DatabaseContextSchool : DbContext
{
    public DbSet<Person>? persons { get; set; }
    public DbSet<Level>? levels { get; set; }
    public DbSet<Role>? roles { get; set; }
    public DbSet<Professor>? professors { get; set; }
    public DbSet<Student>? students { get; set; }
    public DbSet<User>? users { get; set; }
    public DbSet<Course>? courses { get; set; }

    public DatabaseContextSchool(DbContextOptions<DatabaseContextSchool> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}