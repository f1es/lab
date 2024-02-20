using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Qualification
    {
        public int Id { get; set; }
        public string? Education { get; set; }
        public int? WorkExpirience { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
