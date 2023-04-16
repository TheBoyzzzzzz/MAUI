using SQLite;

namespace StaffManager.Domain.Entities
{
    [Table("Positions")]
    public class Position : Entity
    {
        public int Salary { get; set; }

        public List<PositionResponsibility> PositionResponsibilities = new();

        public Position()
        {
        }

        public Position(string name, int salary) : base(name)
        {
            Salary = salary;
        }
    }
}
