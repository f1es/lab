using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class WorkersTelephone
    {
        public int Id { get; set; }
        public string TelephoneNumber { get; set; } = null!;
        public string? TelephoneType { get; set; }
        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; } = null!;
    }
}
