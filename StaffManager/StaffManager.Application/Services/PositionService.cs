using System.Linq.Expressions;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Services;

public class PositionService : IPositionService
{
    private IUnitOfWork _unitOfWork;

    public PositionService(IUnitOfWork unit)
    {
        _unitOfWork = unit;
    }

    public Task AddAsync(Position item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionRepository.AddAsync(item, cancellationToken);
    }

    public Task DeleteAsync(Position item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionRepository.DeleteAsync(item, cancellationToken);
    }

    public Task<Position> FirstOrDefaultAsync(Expression<Func<Position, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<Position>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionRepository.ListAllAsync(cancellationToken);
    }

    public Task<Position> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Position, object>>[]? includesProperties)
    {
        return _unitOfWork.PositionRepository.GetByIdAsync(id, cancellationToken, includesProperties);
    }

    public Task<IReadOnlyList<PositionResponsibility>> GetResponsibilitiesListAsync(int positionId, CancellationToken cancellationToken = default)
    {
        var pos = _unitOfWork.PositionRepository.ListAsync((pos) => pos.Id == positionId, cancellationToken).Result;
        var res = pos.Select(x => x.PositionResponsibilities).First().ToList().AsReadOnly();
        return Task.FromResult((IReadOnlyList<PositionResponsibility>)res);
    }

    public Task<IReadOnlyList<Position>> ListAsync(Expression<Func<Position, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Position, object>>[]? includesProperties)
    {
        return _unitOfWork.PositionRepository.ListAsync(filter, cancellationToken, includesProperties);
    }

    public Task UpdateAsync(Position item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionRepository.UpdateAsync(item, cancellationToken);
    }

    public Task SaveChangesAsync()
    {
        return _unitOfWork.SaveAllAsync();
    }
}
