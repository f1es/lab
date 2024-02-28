using DataBaseInterface.Models;
using System;
using System.Collections.Generic;

namespace DataBaseInterface.Entities
{
    public partial class Speciality : IDBEntity
    {
        public Speciality()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string SpecialityName { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
