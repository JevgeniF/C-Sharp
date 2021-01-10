using System.Runtime.InteropServices;

namespace Domain
{
    public class BattleShipLog
    {
        public string move { get; set; } = null!;

        public BattleShipLog() {}

        public BattleShipLog(string move)
        {
            this.move = move;
        }
    }
}