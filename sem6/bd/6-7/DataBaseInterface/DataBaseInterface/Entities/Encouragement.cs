using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Encouragement
    {
        public int Id { get; set; }
        public string EncouragementName { get; set; } = null!;
    }
}
