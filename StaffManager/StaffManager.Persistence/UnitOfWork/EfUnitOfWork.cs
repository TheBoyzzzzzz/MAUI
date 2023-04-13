using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;
using StaffManager.Persistence.Data;
using StaffManager.Persistence.Repository;

namespace StaffManager.Persistence.UnitOfWork;
public class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Lazy<IRepository<Position>> _positionRepository;
    private readonly Lazy<IRepository<PositionResponsibility>> _positionResponsibilityRepository;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
        _positionRepository = new Lazy<IRepository<Position>>(() =>
        new EfRepository<Position>(context));
        _positionResponsibilityRepository = new Lazy<IRepository<PositionResponsibility>>(() =>
        new EfRepository<PositionResponsibility>(context));
    }

    public IRepository<Position> PositionRepository => _positionRepository.Value;

    public IRepository<PositionResponsibility> PositionResponsibilityRepository => _positionResponsibilityRepository.Value;

    public async Task CreateDatabaseAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }
    public async Task RemoveDatbaseAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }
    public async Task SaveAllAsync()
    {
        await _context.SaveChangesAsync();
    }
}
