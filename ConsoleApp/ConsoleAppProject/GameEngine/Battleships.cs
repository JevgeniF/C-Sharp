using System;
using System.Text.Json;

namespace GameEngine
{
    public class Battleships
    {
        public static int Width = 10;
        public static string MoveCoordinates = "";
        private readonly CellState[,] _board = new CellState[Width, Width];
        private static bool _nextMoveByFirst = true;
        private static CellState[][,] _boards = null!;

        public CellState[][,] GetBoards()
        {
            var res1 = new CellState[Width, Width];
            Array.Copy(_board, res1, _board.Length);
            var res2 = new CellState[Width, Width];
            Array.Copy(_board, res2, _board.Length);
            var resses = new[] {res1, res2};
            _boards = resses;
            return resses;
        }

        public static bool NextMoveByFirst => _nextMoveByFirst;

        public static bool MakeAMove(CellState[,] board)
        {
            int attackCol = (char.ToUpper(MoveCoordinates[0]) - 65);
            int attackRow = Width + 1;
            bool success = Int32.TryParse((MoveCoordinates.Substring(1)), out int number);
            if (success)
            {
                attackRow = number - 1;
            }

            if (attackCol >= Width || attackRow >= Width)
            {
                Console.WriteLine("Commander, your hands are shaking! Stay focused!");
            }
            else if (board[attackCol, attackRow] == CellState.Empty)
            {
                board[attackCol, attackRow] = _nextMoveByFirst ? CellState.O : CellState.T;
                _nextMoveByFirst = !_nextMoveByFirst;
                return true;
            }

            return false;
        }

        public string GetSerializedGameState()
        {
            var state = new GameState
            {
                NextMoveByFirst = _nextMoveByFirst, Width = _board.GetLength(0), Height = _board.GetLength(1)
            };
            state.BoardOne = new CellState[state.Width][];
            
            for (var i = 0; i < state.BoardOne.Length; i++)
            {
                state.BoardOne[i] = new CellState[state.Height];
            }

            for (var x = 0; x < state.Width; x++)
            {
                for (var y = 0; y < state.Height; y++)
                {
                    state.BoardOne[x][y] = _boards[0][x, y];
                }
            }
            
            
            
            
            state.BoardTwo = new CellState[state.Width][];
            for (var i = 0; i < state.BoardTwo.Length; i++)
            {
                state.BoardTwo[i] = new CellState[state.Height];
            }
            
            for (var x = 0; x < state.Width; x++)
            {
                for (var y = 0; y < state.Height; y++)
                {
                    state.BoardTwo[x][y] = _boards[1][x, y];
                }
            }
            var jsonOption = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            
            return JsonSerializer.Serialize(state, jsonOption);
        }

        public void SetGameStateFromJson(string jsonString)
        {
            var state = JsonSerializer.Deserialize<GameState>(jsonString);
            _nextMoveByFirst = state.NextMoveByFirst;
            _boards[0] = new CellState[state.Width, state.Height];
            for (var x = 0; x < state.Width; x++)
            {
                for (var y = 0; y < state.Height; y++)
                {
                    _boards[0][x, y] = state.BoardOne[x][y];
                }
            }
            _boards[1] = new CellState[state.Width, state.Height];
            for (var x = 0; x < state.Width; x++)
            {
                for (var y = 0; y < state.Height; y++)
                {
                    _boards[1][x, y] = state.BoardTwo[x][y];
                }
            }
        }
    }
    
}