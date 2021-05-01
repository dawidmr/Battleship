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

        public Engine(IGridCreator gridCreator, ITargetStrategy targetStrategy, IConfigService configService, ILogger<Engine> logger)
        {
            _gridCreator = gridCreator;
            _targetStrategy = targetStrategy;
            _configService = configService;
            _logger = logger;
        }
        
        public async Task<IPlayer> CreatePlayerAsync(string name)
        {
            Configuration config;

            try
            {
                config = await _configService.GetConfigurationAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get configuration");
                throw;
            }

            try
            {
                return new Player(_gridCreator, _targetStrategy, config.GridSize, config.Ships, name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create player");
                throw;
            }
        }

        public bool Play(IPlayer attacker, IPlayer victim)
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
                _logger.LogError("Failed to play", ex);
                throw;
            }

            return isStillInGame;
        }
    }
}
