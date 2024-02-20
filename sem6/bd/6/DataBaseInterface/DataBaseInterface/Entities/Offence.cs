using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Offence
    {
        public int Id { get; set; }
        public string OffenceName { get; set; } = null!;
        public string Punishment { get; set; } = null!;
    }
}
