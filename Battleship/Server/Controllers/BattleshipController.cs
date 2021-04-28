using Battleship.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Battleship.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            var config = new Configuration()
            {
                GridSize = 10,
                Ships = new List<Ship>() {
                    new Ship() { Size = 1, Count = 4 },
                    new Ship() { Size = 2, Count = 3 },
                    new Ship() { Size = 3, Count = 2 },
                    new Ship() { Size = 4, Count = 1 }
                }
            };

            return new JsonResult(config);
        }
    }
}
