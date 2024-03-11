namespace WebApplication_ASP_NET_Core_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public static class UsersDB
    {
        public static List<User> list = new List<User>() 
        {
        new User()
        {
            Name = "vasya",
            Age = 22,     
            Email = "v@mail.net",     
            Id = 1          
        },
        new User()
        {
            Name = "Petya",
            Age = 25,
            Email = "p@mail.net",
            Id = 2
        }
    };
    }
}
