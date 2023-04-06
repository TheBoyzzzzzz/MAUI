using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Staff")]
    public class Staff
    {
        [PrimaryKey, Indexed, AutoIncrement ]
        public int Id { get; init; }
        [NotNull, Unique]
        public string Name { get; set; } = "";
        public int Selary { get; set; }
    }
}
