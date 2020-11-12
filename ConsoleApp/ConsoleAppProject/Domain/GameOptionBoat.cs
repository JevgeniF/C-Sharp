using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class GameOptionBoat
    {
        public int GameOptionBoatId { get; set; }

        [Range(1, int.MaxValue)] public int Amount { get; set; }

        public int BoardId { get; set; }
        public Boat? Boat { get; set; }

        public int GameOptionId { get; set; }
        public GameOption? GameOption { get; set; }
    }
}