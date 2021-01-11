using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Boat
    {
        public int BoatId { get; set; }

        [MaxLength(32)] public string Name { get; set; } = null!;
        [Range(1, int.MaxValue)] public int Size { get; set; }
        [Range(1, int.MaxValue)] public int Quantity { get; set; }

        public int GameOptionsId { get; set; }
        
        public GameOptions? GameOptions { get; set; }

        public override string ToString()
        {
            return $"TYPE {Name} : size is {Size}, available quantity is {Quantity}.";
        }
    }
}