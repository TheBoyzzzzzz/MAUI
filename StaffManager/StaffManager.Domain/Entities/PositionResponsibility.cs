using SQLite;

namespace StaffManager.Domain.Entities;

[Table("PositionResponsibilities")]
public class PositionResponsibility : Entity
{
    public PositionResponsibility()
    {
    }

    public PositionResponsibility(string name, string description, int importance) : base(name)
    {
        Description = description;
        Importance = importance;
    }

    public PositionResponsibility(string name, string description, int importance, string photoPath) : base(name)
    {
        Description = description;
        Importance = importance;
        PhotoPath = photoPath;
    }

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    public int Importance { get; init; }

    public string PhotoPath { get; set; }

    public Position Position { get; set; } = new();
}
