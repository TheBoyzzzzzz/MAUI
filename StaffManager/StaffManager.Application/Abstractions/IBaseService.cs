using System.Linq.Expressions;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Abstractions;

public interface IBaseService<T> where T : Entity
{
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[]? includesProperties);

    Task AddAsync(T item, CancellationToken cancellationToken = default);

    Task UpdateAsync(T item, CancellationToken cancellationToken = default);

    Task DeleteAsync(T item, CancellationToken cancellationToken = default);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
   cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter,
    CancellationToken cancellationToken = default,
    params Expression<Func<T, object>>[]? includesProperties);
}
