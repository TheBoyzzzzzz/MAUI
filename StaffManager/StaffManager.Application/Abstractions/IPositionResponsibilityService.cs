using StaffManager.Domain.Entities;

namespace StaffManager.Application.Abstractions
{
    public interface IPositionResponsibilityService<T> : IBaseService<T> where T : PositionResponsibility
    {

    }
}
