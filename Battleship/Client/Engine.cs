using Battleship.Client.Services;
using Battleship.Game;
using Battleship.Game.Interfaces;
using System;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public class Engine : IEngine
    {
        private IGridCreator gridCreator;
        private ITargetStrategy targetStrategy;
        private IConfigService configService;
        
        public Engine(IGridCreator _gridCreator, ITargetStrategy _targetStrategy, IConfigService _configService)
        {
            gridCreator = _gridCreator;
            targetStrategy = _targetStrategy;
            configService = _configService;
        }

        public IPlayer CreatePlayer()
        {
            var config = configService.GetConfiguration();
            return new Player(gridCreator, targetStrategy, config.GridSize, config.Ships);
        }

        public async Task<IPlayer> CreatePlayerAsync()
        {
            var config = await configService.GetConfigurationAsync();
            return new Player(gridCreator, targetStrategy, config.GridSize, config.Ships);
        }

        public bool Play(IPlayer attacker, IPlayer victim)
        {
            var target = attacker.ChooseTarget();
            var newTarget1State = victim.Shot(target);
            attacker.UpdateOpponentGrid(target, newTarget1State);

            return victim.HasAnyShips();
        }
    }
}
