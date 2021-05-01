namespace Battleship.Models
{
    public class ShipPrototype
    {
        public string Name { get; }
        public int Size { get; }
        public int Count { get; }

        public ShipPrototype(string name, int size, int count)
        {
            Name = name;
            Size = size;
            Count = count;
        }
    }
}
