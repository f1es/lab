using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Worker
    {
        public Worker()
        {
            JobVacancies = new HashSet<JobVacancy>();
            WorkersTelephones = new HashSet<WorkersTelephone>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleNames { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int? SpecialityId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Speciality? Speciality { get; set; }
        public virtual ICollection<JobVacancy> JobVacancies { get; set; }
        public virtual ICollection<WorkersTelephone> WorkersTelephones { get; set; }
    }
}
