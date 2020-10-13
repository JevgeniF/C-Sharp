namespace GameEngine
{
    public class GameState
    {
        public bool NextMoveByOne { get; set; }
        public CellState[][] Board { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }

    }
}