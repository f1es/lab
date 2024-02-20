using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleNames { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public virtual Company? Company { get; set; }
    }
}
