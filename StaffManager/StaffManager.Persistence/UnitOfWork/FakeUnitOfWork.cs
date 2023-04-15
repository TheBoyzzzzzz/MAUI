using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;
using StaffManager.Persistence.Data;
using StaffManager.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Persistence.UnitOfWork
{
    internal class FakeUnitOfWork
    {
        private readonly Lazy<IRepository<Position>> _positionRepository;
        private readonly Lazy<IRepository<PositionResponsibility>> _positionResponsibilityRepository;

        public FakeUnitOfWork()
        {
            _positionRepository = new Lazy<IRepository<Position>>(() =>
            new FakePositionRepository());
            _positionResponsibilityRepository = new Lazy<IRepository<PositionResponsibility>>(() =>
            new FakePositionResponsibilitiesRepository());
        }

        public IRepository<Position> PositionRepository => _positionRepository.Value;

        public IRepository<PositionResponsibility> PositionResponsibilityRepository => _positionResponsibilityRepository.Value;

    }
}
