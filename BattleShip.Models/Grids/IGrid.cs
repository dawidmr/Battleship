using Battleship.Shared;

namespace BattleShip.Models
{
    public interface IGrid
    {
        void ChangeSquareState(Coordinates coordinates, SquareStates newState);
        void Fill();
    }
}