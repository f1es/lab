using System.Data.Entity;

namespace WebApplication_ASP_NET_Core_MVC.Models
{
	public class MarketBDContext : DbContext
	{
		private static MarketBDContext _Context;
		public DbSet<User> Users { get; set; }
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
