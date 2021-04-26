using Battleship.Game;
using Battleship.Shared;
using BattleShip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleShipController : ControllerBase
    {
        private readonly ILogger<BattleShipController> logger;
        private readonly IGridCreator gridCreator;

        public BattleShipController(ILogger<BattleShipController> _logger, IGridCreator _gridCreator)
        {
            logger = _logger;
            gridCreator = _gridCreator;
        }

        [HttpGet]
        public IPlayer GetPlayer()
        {
            // TODO: inject player?
            return new Player(gridCreator);
        }

        [HttpGet]
        public SquareStates[,] CreateGrid(int size, GridType type)
        {
            return gridCreator.Create(type);
        }
    }
}
