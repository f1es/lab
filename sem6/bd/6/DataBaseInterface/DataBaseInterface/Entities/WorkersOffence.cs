using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class WorkersOffence
    {
        public int OffenceId { get; set; }
        public int WorkerId { get; set; }

        public virtual Offence Offence { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
