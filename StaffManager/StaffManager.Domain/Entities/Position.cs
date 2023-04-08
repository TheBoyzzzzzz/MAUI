using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Positions")]
    public class Position : Entity
    {
        public int Selary { get; set; }
    }
}
