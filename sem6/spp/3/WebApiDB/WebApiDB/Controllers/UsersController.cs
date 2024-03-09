using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text.Json;
using System.Web;
using Newtonsoft.Json;

namespace WebApiDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<string>> Get()
        {
            var users = await UserContext.GetInstance().Users.ToListAsync();
            var json = JsonConvert.SerializeObject(users);
            return json;
        }
        [HttpGet]
        [Route("GetUser/{id:int}")]
        public async Task<ActionResult<string>> Get(int id)
        {

            var user = await UserContext.GetInstance().Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            await UserContext.GetInstance().SaveChangesAsync();
            var json = JsonConvert.SerializeObject(user);
            return json;

        }
        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public async Task<ActionResult<User>> Delete(int id)
        {

            var deletingUser = await UserContext.GetInstance().Users.Where(u => u.Id == id).SingleAsync();
            if (deletingUser == null)
            {
                return NotFound();
            }
            UserContext.GetInstance().Users.Remove(deletingUser);
            await UserContext.GetInstance().SaveChangesAsync();
            return Ok(deletingUser);

        }
        [HttpPost]
        [Route("PostUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserContext.GetInstance().Users.Add(user);
            await UserContext.GetInstance().SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        [Route("PutUser")]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
                return BadRequest();
            var updUser = await UserContext.GetInstance().Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (updUser == null)
                return BadRequest();

            updUser.Name = user.Name;
            updUser.Email = user.Email;
            updUser.Age = user.Age;

            await UserContext.GetInstance().SaveChangesAsync();
            return Ok(updUser);
        }
    }
}
