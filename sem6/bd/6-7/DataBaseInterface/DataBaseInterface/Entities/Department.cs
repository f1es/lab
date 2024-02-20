using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
