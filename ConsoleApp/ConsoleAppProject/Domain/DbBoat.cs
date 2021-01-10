using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DbBoat
    {
        [Key]
        public int BoatId { get; set; }

        [Range(1, int.MaxValue)] public int Size { get; set; }
        [Range(1, int.MaxValue)] public int Quantity { get; set; }

        [MaxLength(32)] public string Name { get; set; } = null!;

        public int GameOptionId { get; set; }
        public GameOptions? GameOption { get; set; }

        public override string ToString()
        {
            return $"TYPE {Name} : size is {Size}, available quantity is {Quantity}.";
        }
    }
}