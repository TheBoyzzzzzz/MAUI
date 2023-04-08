using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
