using System.Linq.Expressions;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Services;

public class PositionResponsibilityService : IPositionResponsibilityService
{
    private readonly IUnitOfWork _unitOfWork;

    public PositionResponsibilityService(IUnitOfWork unit)
    {
        _unitOfWork = unit;
    }

    public Task AddAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionResponsibilityRepository.AddAsync(item, cancellationToken);
    }

    public Task DeleteAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionResponsibilityRepository.DeleteAsync(item, cancellationToken);
    }

    public Task<PositionResponsibility> FirstOrDefaultAsync(Expression<Func<PositionResponsibility, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionResponsibilityRepository.FirstOrDefaultAsync(filter, cancellationToken);
    }

    public Task<IReadOnlyList<PositionResponsibility>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionResponsibilityRepository.ListAllAsync(cancellationToken);
    }

    public Task<PositionResponsibility> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<PositionResponsibility, object>>[]? includesProperties)
    {
        return _unitOfWork.PositionResponsibilityRepository.GetByIdAsync(id, cancellationToken, includesProperties);
    }

    public Task<IReadOnlyList<PositionResponsibility>> ListAsync(Expression<Func<PositionResponsibility, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<PositionResponsibility, object>>[]? includesProperties)
    {
        return _unitOfWork.PositionResponsibilityRepository.ListAsync(filter, cancellationToken, includesProperties);
    }

    public Task UpdateAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.PositionResponsibilityRepository.UpdateAsync(item, cancellationToken);
    }

    public Task SaveChangesAsync()
    {
        return _unitOfWork.SaveAllAsync();
    }
}

