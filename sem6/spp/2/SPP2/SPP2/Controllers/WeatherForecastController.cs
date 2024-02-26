using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;


namespace SPP2.Controllers
{
    [ApiController]
    [Route("Msg")]
    public class MessageController : ControllerBase
    {
        [HttpGet(Name = "GetMessage")]
        public string GetString()
        {
            return "HELLO";
        }
    }

    [ApiController]
    [Route("Picture")]
    public class PictureController : ControllerBase
    {
        string? imageSource = @"X:\vs\SPP2\SPP2\png-clipart-gray-stone-rock-stone-image-file-formats-stone-carving-thumbnail.png";
        [HttpGet(Name = "GetPicture")]
        public IActionResult Get()
        {
            var image = System.IO.File.OpenRead(imageSource);
            return File(image, "image/png");
        }
    }

    [ApiController]
    [Route("Table")]
    public class TableController : ControllerBase
    {
        List<Human> humans = new List<Human>() { new Human() { Name = "Vasya", Age = 19 }, new Human() { Name = "Petya", Age = 21 } };


        [HttpGet(Name = "GetTable")]
        public string Get()
        {
            return JsonConvert.SerializeObject(humans);
        }
    }
}