using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSPP3Practice
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Employee> Employees { get; set; }
		public virtual Director Directors { get; set; }
	}
}
