using Battleship.Shared;
using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Game
{
    public class Player : IPlayer
    {
        public IGrid MainGrid { get; set; }
        public IGrid OpponentGrid { get; set; }

        public List<Ship> ships = new List<Ship>()
        {
            new Ship() {Size = 1, Count = 4 },
            new Ship() {Size = 2, Count = 3 },
            new Ship() {Size = 3, Count = 2 },
            new Ship() {Size = 4, Count = 1 }
        };

        public Player(IGridCreator gridCreator)
        {
            MainGrid = gridCreator.Create(GridType.Main, ships);
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
