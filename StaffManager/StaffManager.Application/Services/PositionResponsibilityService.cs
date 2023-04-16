using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StaffManager.Application.Abstractions;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Services
{
    public class PositionResponsibilityService : IPositionResponsibilityService
    {
        private IUnitOfWork _unitOfWork;

        public PositionResponsibilityService(IUnitOfWork unit) {

            _unitOfWork = unit;
             
        }

        public Task AddAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
        {
            return  _unitOfWork.PositionResponsibilityRepository.AddAsync(item, cancellationToken);
        }

        public Task DeleteAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
        {
           
            return _unitOfWork.PositionResponsibilityRepository.DeleteAsync(item);
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
            return _unitOfWork.PositionResponsibilityRepository.GetByIdAsync(id);
        }

        public Task<IReadOnlyList<PositionResponsibility>> ListAsync(Expression<Func<PositionResponsibility, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<PositionResponsibility, object>>[]? includesProperties)
        {
            return _unitOfWork.PositionResponsibilityRepository.ListAsync(filter);
        }

        public Task UpdateAsync(PositionResponsibility item, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.PositionResponsibilityRepository.UpdateAsync(item, cancellationToken);
        }
    }
}

