using StaffManager.Domain.Entities;

namespace StaffManager.Application.Abstractions
{
    public interface IPositionService<T> : IBaseService<T> where T : Position
    {
        Task<IReadOnlyList<T>> GetResponsibilitiesListAsync(int positionId, CancellationToken cancellationToken = default);
    }
}
