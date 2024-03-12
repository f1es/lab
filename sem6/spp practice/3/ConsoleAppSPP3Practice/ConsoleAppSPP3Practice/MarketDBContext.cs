using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSPP3Practice
{
	public class MarketBDContext : DbContext
	{
		private static MarketBDContext _Context;
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Director> Directors { get; set; }
		public DbSet<Department> Departments { get; set; }
		private MarketBDContext() : base("MarketDB")
		{ }
		public static MarketBDContext GetInstance()
		{
			if (_Context == null)
				_Context = new MarketBDContext();
			return _Context;
		}
	}
}
