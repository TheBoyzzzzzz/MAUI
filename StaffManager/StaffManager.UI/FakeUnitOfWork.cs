using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Persistence.UnitOfWork;

public class FakeUnitOfWork : IUnitOfWork
{
    private readonly Lazy<IRepository<Position>> _positionRepository;
    private readonly Lazy<IRepository<PositionResponsibility>> _positionResponsibilityRepository;

    public FakeUnitOfWork()
    {
        /*_positionRepository = new Lazy<IRepository<Position>>(() =>
        new FakePositionRepository());
        _positionResponsibilityRepository = new Lazy<IRepository<PositionResponsibility>>(() =>
        new FakePositionResponsibilitiesRepository());*/
    }

    public IRepository<Position> PositionRepository => _positionRepository.Value;

    public IRepository<PositionResponsibility> PositionResponsibilityRepository => _positionResponsibilityRepository.Value;

    public Task RemoveDatbaseAsync() => throw new NotImplementedException();
    public Task CreateDatabaseAsync() => throw new NotImplementedException();
    public Task SaveAllAsync() => throw new NotImplementedException();
}
