using Battleship.Shared;
using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class Player : IPlayer
    {
        protected IGrid MainGrid { get; set; }
        protected IGrid OpponentGrid { get; set; }

        public Player(IGridCreator gridCreator)
        {
            MainGrid = gridCreator.Create(GridType.Main);
            OpponentGrid = gridCreator.Create(GridType.Opponent);
        }

        public Coordinates ChooseTarget()
        {
            throw new NotImplementedException();
        }

        public bool HasAnyShips()
        {
            throw new NotImplementedException();
        }

        Coordinates IPlayer.ChooseTarget()
        {
            throw new NotImplementedException();
        }

        public SquareStates Shot(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
