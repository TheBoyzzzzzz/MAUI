using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Positions")]
    public class Position
    {
        [PrimaryKey, Indexed, AutoIncrement ]
        public int Id { get; init; }
        [NotNull, Unique]
        public string Name { get; set; } = string.Empty;
        public int Selary { get; set; }
    }
}
