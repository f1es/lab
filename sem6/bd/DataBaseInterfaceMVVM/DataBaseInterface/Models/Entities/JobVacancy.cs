using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class JobVacancy
    {
        public int Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? WorkerId { get; set; }
        public int? EmployeeId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        public virtual Worker? Worker { get; set; }
    }
}
