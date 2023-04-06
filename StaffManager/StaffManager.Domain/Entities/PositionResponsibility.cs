using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("PositionResponsibilities")]
    public class PositionResponsibility
    {
        [PrimaryKey, Indexed, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public int Importance { get; init; }

        [Indexed]
        public int PositionID { get; set; }
    }
}
