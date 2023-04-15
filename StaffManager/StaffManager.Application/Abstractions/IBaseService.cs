using StaffManager.Domain.Entities;
using System.Linq.Expressions;

namespace StaffManager.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties);
        Task<T> AddAsync(T item, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T item, CancellationToken cancellationToken = default);
        Task<T> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
       cancellationToken = default);
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[]? includesProperties);

    }
}
