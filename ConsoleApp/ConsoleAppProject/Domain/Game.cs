using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Game
    {
        public int GameId { get; set; }

        public int GameOptionId { get; set; }
        public GameOption? GameOption { get; set; }

        [MaxLength(512)]
        public string Description { get; set; } = DateTime.Now.ToLongDateString();

        public int PlayerAId { get; set; }
        //[ForeignKey(nameof(PlayerAId))]
        //[InverseProperty(nameof(Player.Game))]
        public Player? PlayerA { get; set; }

        public int PlayerBId { get; set; }
        //[ForeignKey(nameof(PlayerBId))]
        //[InverseProperty(nameof(Player.Game))]
        public Player? PlayerB { get; set; }
    }
}