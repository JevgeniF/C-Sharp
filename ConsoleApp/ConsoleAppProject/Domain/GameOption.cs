using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain
{
    public class GameOption
    {
        public int GameOptionId { get; set; }

        [MaxLength(128)] public string Name { get; set; } = null!;

        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

        public EBoatsCanTouch EBoatsCanTouch { get; set; }

        public ENextMoveAfterHit ENextMoveAfterHit { get; set; }

        public ICollection<GameOptionBoat>? GameOptionBoats { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}