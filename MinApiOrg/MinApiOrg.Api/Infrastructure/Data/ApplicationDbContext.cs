using Microsoft.EntityFrameworkCore;
using MinApiOrg.Api.Domain.Entities;

namespace MinApiOrg.Api.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);

        base.OnModelCreating(modelBuilder);
    }
}
