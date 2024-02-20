using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class ProffesionsVacancy
    {
        public int VacancyId { get; set; }
        public int ProffesionId { get; set; }

        public virtual Proffesion Proffesion { get; set; } = null!;
        public virtual JobVacancy Vacancy { get; set; } = null!;
    }
}
