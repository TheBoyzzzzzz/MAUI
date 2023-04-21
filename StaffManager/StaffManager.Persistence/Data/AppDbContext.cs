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
}
