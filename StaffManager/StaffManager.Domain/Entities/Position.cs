using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Positions")]
    public class Position : Entity
    {
        public int Salary { get; set; }
    }
}
