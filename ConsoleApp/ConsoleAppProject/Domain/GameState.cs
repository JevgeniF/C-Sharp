using Domain.Enums;

namespace Domain
{
    public class GameState
    {
        public bool NextMoveByFirst { get; set; }
        public ECellState[][] PlayerOneBoard { get; set; } = null!;
        public GameBoat[] PlayerOneBoats { get; set; } = null!;
        
        public ECellState[][] PlayerTwoBoard { get; set; } = null!;
        public GameBoat[] PlayerTwoBoats { get; set; } = null!;
        
        public BattleShipLog[] BattleShipLogs { get; set; } = null!;
        
        public int Side { get; set; }
    }
}