namespace Battleship.Models
{
    public interface IFillStrategy
    {
        void Fill(ref SquareStates[,] squares);
    }
}