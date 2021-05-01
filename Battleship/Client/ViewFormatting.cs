using Battleship.Models;

namespace Battleship.Client
{
    public class ViewFormatting
    {
        public static string GetFormat(SquareStates state)
        {
            switch (state)
            {
                case SquareStates.Ship:
                    return "bg-primary";
                case SquareStates.HittedShip:
                    return "bg-warning";
                case SquareStates.SunkShip:
                    return "bg-danger";
                case SquareStates.Virgin:
                    return "bg-white";
                case SquareStates.MissedShot:
                    return "bg-secondary";
                default:
                    return "bg-white";
            }
        }

        public static char GetCharFromSquareState(SquareStates state)
        {
            switch (state)
            {
                case SquareStates.Ship:
                case SquareStates.HittedShip:
                case SquareStates.Virgin:
                    return ' ';
                case SquareStates.SunkShip:
                    return 'X';
                case SquareStates.MissedShot:
                    return '*';
                default:
                    return '?';
            }
        }
    }
}
