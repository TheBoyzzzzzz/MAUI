using System.Linq.Expressions;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Persistence.Repository;
public class FakePositionRepository : IRepository<Position>
{
    List<Position> _positions;
    public FakePositionRepository()
    {
        _positions = new List<Position>()
        {
            new Position {Name = "SEO", Salary=1000, Id = 1},
            new Position {Name = "Manager", Salary = 500, Id = 2},
            new Position { Name = "Employee", Salary = 100, Id = 3}
        };
    }

    public Task<Position> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Position, object>>[]? includesProperties) => throw new NotImplementedException();
    public async Task<IReadOnlyList<Position>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _positions);
    }
    public Task<IReadOnlyList<Position>> ListAsync(Expression<Func<Position, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Position, object>>[]? includesProperties) => throw new NotImplementedException();
    public Task AddAsync(Position entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateAsync(Position entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task DeleteAsync(Position entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<Position> FirstOrDefaultAsync(Expression<Func<Position, bool>> filter, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
