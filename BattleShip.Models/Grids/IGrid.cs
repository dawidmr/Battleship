namespace BattleShip.Models
{
    public interface IGrid
    {
        int Size { get; }
        GridType Type { get; }

        void ChangeSquareState(Coordinates coordinates, SquareStates newState);
        void Fill(IFillStrategy fillStrategy);
    }
}