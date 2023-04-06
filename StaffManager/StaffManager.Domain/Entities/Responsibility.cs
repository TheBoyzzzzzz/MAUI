using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Responsibilities")]
    public class Responsibility
    {
        [PrimaryKey, Indexed, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public int Importance { get; init; }

        [Indexed]
        public int EmployeePositionID { get; set; }
    }
}
