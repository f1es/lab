using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class WorkersDepartment
    {
        public int DepartmentId { get; set; }
        public int WorkerId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
