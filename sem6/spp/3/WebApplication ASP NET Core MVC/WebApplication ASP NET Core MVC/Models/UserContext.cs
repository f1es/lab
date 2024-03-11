using System.Data.Entity;

namespace WebApplication_ASP_NET_Core_MVC.Models
{
	public class UserContext : DbContext
	{
		private static UserContext _userContext;
		public DbSet<User> Users { get; set; }
		private UserContext() : base("UsersDataBase")
		{ }
		public static UserContext GetInstance()
		{
			if (_userContext == null)
				_userContext = new UserContext();
			return _userContext;
		}
	}
}
