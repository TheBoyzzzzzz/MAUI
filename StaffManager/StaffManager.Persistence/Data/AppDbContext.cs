using Microsoft.EntityFrameworkCore;
using StaffManager.Domain.Entities;

namespace StaffManager.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
        
    }

    public DbSet<Position> Positions { get; set; }
    public DbSet<PositionResponsibility> PositionResponsibilities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Position>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Position>().Property(p => p.Name).IsRequired();
        builder.Entity<Position>().Property(p => p.Salary).IsRequired();
        builder.Entity<Position>().HasMany(p => p.PositionResponsibilities).WithOne(pr => pr.Position);

        builder.Entity<PositionResponsibility>().Property(pr => pr.Id).ValueGeneratedOnAdd();
        builder.Entity<PositionResponsibility>().Property(pr => pr.Name).IsRequired();
        builder.Entity<PositionResponsibility>().Property(pr => pr.Description).IsRequired();
        builder.Entity<PositionResponsibility>().Property(pr => pr.Importance).IsRequired();
        builder.Entity<PositionResponsibility>().Property(pr => pr.PhotoPath).IsRequired();
        builder.Entity<PositionResponsibility>().HasOne(pr => pr.Position).WithMany(p => p.PositionResponsibilities);
    }
}
