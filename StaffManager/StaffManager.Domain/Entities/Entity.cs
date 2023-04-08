using SQLite;

namespace StaffManager.Domain.Entities
{
    public abstract class Entity
    {
        [PrimaryKey, Indexed, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
