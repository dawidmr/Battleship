using Battleship.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Battleship.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            var jsonConfig = System.IO.File.ReadAllText("./Configuration/BattleshipConfiguration.json");
            var config = JsonSerializer.Deserialize<Configuration>(jsonConfig);

            return new JsonResult(config);
        }
    }
}
