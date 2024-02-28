using DataBaseInterface.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DataBaseInterface.Entities
{
    public partial class Director : IDBEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleNames { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public virtual Company? Company { get; set; }

        public FullName FullName { get =>  new FullName(FirstName, MiddleNames, LastName); }

	}
}
