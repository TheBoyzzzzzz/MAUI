using StaffManager.Domain.Entities;

namespace StaffManager.Domain.Abstractions;
public interface IUnitOfWork
{
    IRepository<Position> PositionRepository { get; }
    IRepository<PositionResponsibility> PositionResponsibilityRepository { get; }
    public Task RemoveDatbaseAsync();
    public Task CreateDatabaseAsync();
    public Task SaveAllAsync();
}
