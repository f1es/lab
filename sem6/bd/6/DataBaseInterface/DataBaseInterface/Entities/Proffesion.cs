using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Proffesion
    {
        public int Id { get; set; }
        public string ProffesionName { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
