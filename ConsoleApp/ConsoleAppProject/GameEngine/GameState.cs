namespace GameEngine
{
    public class GameState
    {
        public bool NextMoveByFirst { get; set; }
        public CellState[][] BoardOne { get; set; } = null!;
        public CellState[][] BoardTwo { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }
    }
}