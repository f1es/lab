using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class WorkersEncouragement
    {
        public int EncouragementId { get; set; }
        public int WorkerId { get; set; }

        public virtual Encouragement Encouragement { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
