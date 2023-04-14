using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Persistence.Repository;
internal class FakePositionResponsibilitiesRepository : IRepository<PositionResponsibility>
{
    List<PositionResponsibility> _positionResponsibilities;
    public FakePositionResponsibilitiesRepository()
    {
        _positionResponsibilities = new List<PositionResponsibility>()
        {
                new PositionResponsibility {Id=1, Name="Name1", Importance=3,Description = "Managing assets", PositionID = 1 },
                new PositionResponsibility {Id=2, Name="Name2", Importance=1,Description = "Making major decisions", PositionID = 1 },
                new PositionResponsibility {Id=3, Name="Name3", Importance=1,Description = "Setting goals", PositionID = 1 },
                new PositionResponsibility {Id=4, Name="Name4", Importance=4,Description = "Monitor company perfomance", PositionID = 1 },
                new PositionResponsibility {Id=5, Name="Name5", Importance=1,Description = "Setting precedence for the working culture and environment", PositionID = 1 },
                new PositionResponsibility {Id=6, Name="Name6", Importance=1,Description = "Manage the software development team", PositionID = 2 },
                new PositionResponsibility {Id=7, Name="Name7", Importance=10,Description = "Control troject timelines", PositionID = 2 },
                new PositionResponsibility {Id=8, Name="Name8", Importance=1,Description = "Hiring and recruiting", PositionID = 2 },
                new PositionResponsibility {Id=9, Name="Name9", Importance=2,Description = "Manage the tools", PositionID = 2 },
                new PositionResponsibility {Id=10,Name="Name10",Importance=1, Description = "Ensure software quality", PositionID = 2 },
                new PositionResponsibility {Id=11,Name="Name11",Importance=3, Description = "Writing and implementing efficient code", PositionID = 3 },
                new PositionResponsibility {Id=12,Name="Name12",Importance=11, Description = "Maintaining and upgrading existing systems", PositionID = 3 },
                new PositionResponsibility {Id=13,Name="Name13",Importance=1, Description = "Testing and evaluating new programs", PositionID = 3 },
                new PositionResponsibility {Id=14,Name="Name14",Importance=1, Description = "Designing programs", PositionID = 3 },
                new PositionResponsibility {Id=15,Name="Name15",Importance=1, Description = "Training users", PositionID = 3 }
        };
    }
    public Task<PositionResponsibility> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<PositionResponsibility, object>>[]? includesProperties) => throw new NotImplementedException();
    public Task<IReadOnlyList<PositionResponsibility>> ListAllAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public async Task<IReadOnlyList<PositionResponsibility>> ListAsync(Expression<Func<PositionResponsibility, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<PositionResponsibility, object>>[]? includesProperties)
    {
        IQueryable<PositionResponsibility>? query = _positionResponsibilities.AsQueryable();

        if (includesProperties?.Any() ?? false)
        {
            foreach (Expression<Func<PositionResponsibility, object>>? included in includesProperties)
            {
                query = query.Include(included);
            }
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }
    public Task AddAsync(PositionResponsibility entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateAsync(PositionResponsibility entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task DeleteAsync(PositionResponsibility entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<PositionResponsibility> FirstOrDefaultAsync(Expression<Func<PositionResponsibility, bool>> filter, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
