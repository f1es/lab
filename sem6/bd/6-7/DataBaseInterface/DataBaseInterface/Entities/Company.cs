using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
            JobVacancies = new HashSet<JobVacancy>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime BaseDate { get; set; }
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; } = null!;
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<JobVacancy> JobVacancies { get; set; }
    }
}
