using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_ASP_NET_Core_MVC.Models;
using System.Text.Json;

namespace WebApplication_ASP_NET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(string name, int age, string email)
        {
            User user = new User();
            user.Name = name;
            user.Age = age;
            user.Email = email;
            MarketBDContext.GetInstance().Users.Add(user);
			MarketBDContext.GetInstance().SaveChanges();
			return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = MarketBDContext.GetInstance().Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                MarketBDContext.GetInstance().Users.Where(u => u.Id == user.Id).FirstOrDefault().Name = user.Name;
                MarketBDContext.GetInstance().Users.Where(u => u.Id == user.Id).FirstOrDefault().Age = user.Age;
                MarketBDContext.GetInstance().Users.Where(u => u.Id == user.Id).FirstOrDefault().Email = user.Email;
                MarketBDContext.GetInstance().SaveChanges();
                return RedirectToAction("Users");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            User user = MarketBDContext.GetInstance().Users.Where(u => u.Id == id).FirstOrDefault();
			MarketBDContext.GetInstance().Users.Remove(user);
            MarketBDContext.GetInstance().SaveChanges();
            return RedirectToAction("Users");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}