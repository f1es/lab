using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Contract
    {
        public Contract()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
