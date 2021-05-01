namespace Battleship.Models
{
    public class ShipPrototype
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public ShipPrototype()
        {

        }

        public ShipPrototype(string name, int size, int count)
        {
            Name = name;
            Size = size;
            Count = count;
        }
    }
}
