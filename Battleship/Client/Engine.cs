using Battleship.Client.Services;
using Battleship.Game;
using Battleship.Game.Interfaces;
using Battleship.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public class Engine : IEngine
    {
        private IGridCreator _gridCreator;
        private ITargetStrategy _targetStrategy;
        private IConfigService _configService;
        private ILogger<Engine> _logger;
        private Configuration config;
        public string ErrorMessage { get; private set; }

        public Engine(IGridCreator gridCreator, ITargetStrategy targetStrategy, IConfigService configService, ILogger<Engine> logger)
        {
            _gridCreator = gridCreator;
            _targetStrategy = targetStrategy;
            _configService = configService;
            _logger = logger;
        }
        
        public async Task<IPlayer> CreatePlayerAsync(string name)
        {
            try
            {
                config = await _configService.GetConfigurationAsync();
            }
            catch (Exception ex)
            {
                var message = "Failed to get configuration";
                _logger.LogError(ex, message);
                ErrorMessage += message;
            }

            try
            {
                return new Player(_gridCreator, _targetStrategy, config.GridSize, config.Ships, name);
            }
            catch (Exception ex)
            {
                var message = "Failed to create player";
                _logger.LogError(ex, message);
                ErrorMessage += message;
            }

            return null;
        }

        public bool? Play(IPlayer attacker, IPlayer victim)
        {
            bool isStillInGame;

            try
            {
                var target = attacker.ChooseTarget();
                var newTarget1State = victim.Shot(target);
                attacker.UpdateOpponentGrid(target, newTarget1State);
                isStillInGame = victim.HasAnyShips();
            }
            catch (Exception ex)
            {
                var message = "Failed to play";
                _logger.LogError(ex, message);
                ErrorMessage += message;

                return null;
            }

            return isStillInGame;
        }

        public int GetSpeed() => config.SimulationSpeed;
        public int GetSize() => config.GridSize;
    }
}
