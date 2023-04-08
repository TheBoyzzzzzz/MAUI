using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("PositionResponsibilities")]
    public class PositionResponsibility : Entity
    {
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public int Importance { get; init; }

        [Indexed]
        public int PositionID { get; set; }
    }
}
