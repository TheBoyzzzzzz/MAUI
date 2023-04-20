using SQLite;

namespace StaffManager.Domain.Entities;

[Table("PositionResponsibilities")]
public class PositionResponsibility : Entity
{
    public PositionResponsibility()
    {
    }

    public PositionResponsibility(string name, string description, int importance, int positionId) : base(name)
    {
        Description = description;
        Importance = importance;
        PositionId = positionId;
    }

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    public int Importance { get; init; }

    [Indexed]
    public int PositionId { get; set; }
}
