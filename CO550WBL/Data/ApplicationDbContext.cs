using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CO550WBL.Models;

namespace CO550WBL.Data;

public class ApplicationDbContext : IdentityDbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }
  public DbSet<Student> Student { get; set; }
  public DbSet<Course> Course { get; set; }
  public DbSet<Enrollment> Enrollment { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.Entity<Student>().ToTable("Student");
    builder.Entity<Course>().ToTable("Course");
    builder.Entity<Enrollment>().ToTable("Enrollment");
  }
}

