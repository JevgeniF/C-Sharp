using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class GameOptionBoat
    {
        public int GameOptionBoardId { get; set; }

        [Range(1, int.MaxValue)] public int Amount { get; set; }

        public int BoardId { get; set; }
        public Boat? Boat { get; set; }

        public int GameOptionId { get; set; }
        public GameOption? GameOption { get; set; }
    }
}