using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            JobVacancies = new HashSet<JobVacancy>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleNames { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public int ContractId { get; set; }
        public int QualificationId { get; set; }

        public virtual Contract Contract { get; set; } = null!;
        public virtual Qualification Qualification { get; set; } = null!;
        public virtual ICollection<JobVacancy> JobVacancies { get; set; }
    }
}
