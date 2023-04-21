using StaffManager.Domain.Entities;

namespace StaffManager.Application.Abstractions
{
    public interface IPositionService : IBaseService<Position>
    {
        Task<IReadOnlyList<PositionResponsibility>> GetResponsibilitiesListAsync(int positionId, CancellationToken cancellationToken = default);
    }
}
