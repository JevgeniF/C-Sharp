using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using Domain;
using Domain.Enums;

namespace GameLogic
{
    public class Battleships
    {
        public bool NextMoveByFirst = true;
        public bool NextFleetDisplacementByFirst = true;
        public int EndGame = 0;

        private ECellState[,] _playerOneBoard;
        private ECellState[,] _playerTwoBoard;
        private GameBoat[] _playerOneBoatsArray;
        private GameBoat[] _playerTwoBoatsArray;

        private List<BattleShipLog> _shipsLogsList;

        private GameOptions _gameOptions;
        private static int _side;

        public Battleships(GameOptions gameOptions)
        {
            _gameOptions = gameOptions;
            _side = gameOptions.BoardSide;

            _playerOneBoard = new ECellState[gameOptions.BoardSide, gameOptions.BoardSide];
            _playerTwoBoard = new ECellState[gameOptions.BoardSide, gameOptions.BoardSide];
            _playerOneBoatsArray = ShareBoatsToPlayers();
            _playerTwoBoatsArray = ShareBoatsToPlayers();

            _shipsLogsList = new List<BattleShipLog>();
        }

        public int GetSide()
        {
            return _side;
        }

        public (GameBoat[], GameBoat[]) GetBoatsArrays()
        {
            var playerOneBoatsArray = _playerOneBoatsArray;
            var playerTwoBoatsArray = _playerTwoBoatsArray;

            return (playerOneBoatsArray, playerTwoBoatsArray);
        }

        public (ECellState[,], ECellState[,]) GetBoards()
        {
            var playerOneBoard = new ECellState[_side, _side];
            Array.Copy(_playerOneBoard, playerOneBoard, _playerOneBoard.Length);

            var playerTwoBoard = new ECellState[_side, _side];
            Array.Copy(_playerTwoBoard, playerTwoBoard, _playerTwoBoard.Length);

            return (playerOneBoard, playerTwoBoard);
        }

        public IEnumerable<BattleShipLog> GetLog()
        {
            return _shipsLogsList;
        }

        public static int GetBoardSide()
        {
            return _side;
        }

        private GameBoat[] ShareBoatsToPlayers()
        {
            var boatsArray = new GameBoat[_gameOptions.BoatsList.Sum(boat => boat.Quantity)];

            var index = 0;
            foreach (var boat in _gameOptions.BoatsList)
            {
                for (var count = 0; count < boat.Quantity; count++)
                {
                    boatsArray[index] = new GameBoat
                    {
                        Name = boat.Name,
                        Size = boat.Size
                    };
                    index++;
                }
            }

            return boatsArray;
        }

        public void MakeAMove(string target)
        {
            if (EndGame != 0) return;
            
            var attackCol = char.ToUpper(target[0]) - 65;
            var attackRow = _side + 1;
            var success = int.TryParse(target.Substring(1), out var number);
            if (success) attackRow = number - 1;

            if (attackCol >= _side || attackRow >= _side)
            {
                Console.WriteLine("COMMANDER, stop drinking Rum! You can't choose proper coordinates already!");
            }
            else
            {
                var board = _playerOneBoard;
                if (!NextMoveByFirst)
                {
                    board = _playerTwoBoard;
                }

                switch (board[attackCol, attackRow])
                {
                    case ECellState.Empty:
                        board[attackCol, attackRow] = ECellState.Miss;
                        Console.WriteLine("COMMANDER! We hit deep blue ocean! Damn that fog!");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    case ECellState.Wreck:
                        Console.WriteLine("COMMANDER! It is a wreck!");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    case ECellState.Object:
                        board[attackCol, attackRow] = ECellState.Wreck;
                        Console.WriteLine(
                            "COMMANDER! What a nice shot! Seems that I heard armory explosion, but who knows?");
                        switch (_gameOptions.ENextMoveAfterHit)
                        {
                            case ENextMoveAfterHit.OtherPlayer:
                                NextMoveByFirst = !NextMoveByFirst;
                                break;
                            case ENextMoveAfterHit.SamePlayer:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case ECellState.Miss:
                        Console.WriteLine("COMMANDER! Who told that shell doesn't hit the same place twice?");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                WinCheck(board);
            }
        }

        private void WinCheck(ECellState[,] board)
        {
            var shipsLeft = 0;
            for (var row = 0; row < _side; row++)
            {
                for (var col = 0; col < _side; col++)
                {
                    if (board[col, row] == ECellState.Object)
                    {
                        shipsLeft++;
                    }
                }
            }

            if (shipsLeft != 0) return;
            EndGame = 1;
            if (board == _playerOneBoard)
            {//todo ascii
                Console.WriteLine("COMMANDER ONE! Your Honor, enemy DEFEATED, enemy fleet sunk, whole sea area " +
                                  "covered by dead bodies. Only some of enemy seamen still alive. We may save them" +
                                  "or leave them. It is up to you...");
            }
            else
            {
                Console.WriteLine("COMMANDER TWO! Your Honor, enemy DEFEATED, enemy fleet sunk, whole sea area " +
                                  "covered by dead bodies. Only some of enemy seamen still alive. We may save them" +
                                  "or leave them. It is up to you...");
            }
        }

        public void RecordToLog(string target)
        {
            _shipsLogsList.Add(new BattleShipLog(target));
        }

        public void Cheating(int move)
        {
            if (move < 0 && move >= _shipsLogsList.Count) return;
            NextMoveByFirst = true;
            UpdateBoardWithBoats();
            NextFleetDisplacementByFirst = !NextFleetDisplacementByFirst;
            UpdateBoardWithBoats();

            for (var i = 0; i <= move; i++)
            {
                MakeAMove(_shipsLogsList[i].move);
            }

            _shipsLogsList.RemoveRange(move + 1, _shipsLogsList.Count - move - 1);
        }

        public void PlaceBoat(int index, int col, int row)
        {
            var boatsArray = _playerOneBoatsArray;
            if (!NextFleetDisplacementByFirst)
            {
                boatsArray = _playerTwoBoatsArray;
            }

            if (col == -1 && row == -1)
            {
                boatsArray[index].LocationByColumn = col;
                boatsArray[index].LocationByRow = row;
            }

            if (col < 0 || row < 0 || col > _side - 1 || row > _side - 1) return;

            if (row + boatsArray[index].Size > _side && boatsArray[index].IsHor ||
                col + boatsArray[index].Size > _side && !boatsArray[index].IsHor) return;

            boatsArray[index].LocationByColumn = col;
            boatsArray[index].LocationByRow = row;
        }

        public void RotateBoat(int index)
        {
            var boatsArray = _playerOneBoatsArray;
            if (!NextFleetDisplacementByFirst)
            {
                boatsArray = _playerTwoBoatsArray;
            }

            if (boatsArray[index].Size == 1 ||
                boatsArray[index].LocationByRow + boatsArray[index].Size - 1 > _side - 1 && !boatsArray[index].IsHor ||
                boatsArray[index].LocationByColumn + boatsArray[index].Size - 1 > _side - 1 && boatsArray[index].IsHor)
                return;

            boatsArray[index].IsHor = !boatsArray[index].IsHor;
        }

        private static void UpdateBoatOnBoard(GameBoat boat, ECellState[,] board)
        {
            for (var cell = 0; cell < boat.Size; cell++)
            {
                if (boat.IsHor)
                {
                    board[boat.LocationByRow, boat.LocationByColumn + cell] = ECellState.Object;
                    continue;
                }

                board[boat.LocationByRow + cell, boat.LocationByColumn] = ECellState.Object;
            }
        }

        public void UpdateBoardWithBoats()
        {
            var placementBoard = new ECellState[_side, _side];
            var boatsArray = _playerOneBoatsArray;
            if (!NextFleetDisplacementByFirst)
            {
                boatsArray = _playerTwoBoatsArray;
            }

            foreach (var boat in boatsArray)
            {
                if (boat.LocationByColumn >= 0 && boat.LocationByRow >= 0)
                {
                    UpdateBoatOnBoard(boat, placementBoard);
                }
            }

            if (NextFleetDisplacementByFirst)
            {
                _playerOneBoard = placementBoard;
                return;
            }

            _playerTwoBoard = placementBoard;
        }

        public void RandomShipsDisplacement(GameBoat[] boatsArray)
        {
            var random = new Random();

            do
            {
                for (var i = 0; i < boatsArray.Length; i++)
                {
                    var index = random.Next(0, boatsArray.Length);
                    var boat = boatsArray[index];

                    if (boat.LocationByColumn == -1 && boat.LocationByRow == -1)
                    {
                        var isHor = (random.Next(0, 2) == 1);
                        boat.IsHor = isHor;
                    }

                    if (random.Next(0, 100) < 50)
                    {
                        var col = random.Next(0, _side);
                        var row = random.Next(0, _side);
                        Console.WriteLine($"Placing Boats");

                        if (boat.IsHor && col + boat.Size - 1 < _side)
                        {
                            boat.LocationByColumn = col;
                            boat.LocationByRow = row;
                        }

                        if (!boat.IsHor && row + boat.Size - 1 < _side)
                        {
                            boat.LocationByColumn = col;
                            boat.LocationByRow = row;
                        }
                    }
                    else
                    {
                        boat.LocationByColumn = -1;
                        boat.LocationByRow = -1;
                    }

                    UpdateBoardWithBoats();
                }

                var board = _playerOneBoard;
                if (!NextFleetDisplacementByFirst)
                {
                    board = _playerTwoBoard;
                }

                if (!(CheckIfBoatsOverBattleField(boatsArray) || CheckIfBoatsTooClose(boatsArray, board) ||
                      CheckIfFleetNotAsBigAsRequired(boatsArray)))
                {
                    break;
                }
            } while (true);
        }

        public bool CheckIfFleetNotAsBigAsRequired(GameBoat[] boatsArray)
        {
            var countBoats = boatsArray.Count(boat => boat.LocationByRow > -1 && boat.LocationByColumn > -1);
            if (countBoats == 0) return true;
            if (_gameOptions.BoatsCount == -1) return false;
            return countBoats != _gameOptions.BoatsCount;
        }

        public static bool CheckIfBoatsOverBattleField(GameBoat[] boatsArray)
        {
            var shipsCells = 0;
            var shipsOnBoard = 0;
            var checkBoard = new ECellState[_side, _side];

            foreach (var boat in boatsArray)
            {
                if (boat.LocationByRow == -1 && boat.LocationByColumn == -1) continue;

                shipsCells += boat.Size;
                UpdateBoatOnBoard(boat, checkBoard);
            }

            for (var col = 0; col < _side; col++)
            {
                for (var row = 0; row < _side; row++)
                {
                    if (checkBoard[row, col] == ECellState.Object) shipsOnBoard++;
                }
            }

            return shipsCells != shipsOnBoard;
        }

        public bool CheckIfBoatsTooClose(GameBoat[] boatsArray, ECellState[,] board)
        {
            if (_gameOptions.EBoatsCanTouch == EBoatsCanTouch.Yes) return false;

            foreach (var boat in boatsArray)
            {
                if (boat.LocationByColumn == -1 && boat.LocationByRow == -1)
                {
                    continue;
                }

                if (_gameOptions.EBoatsCanTouch != EBoatsCanTouch.No) continue;
                if (CheckBoatCorners(boat, board))
                {
                    return true;
                }

                if (CheckBoatSides(boat, board))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckBoatCorners(GameBoat boat, ECellState[,] board)
        {
            if (boat.IsHor)
            {
                if (!(boat.LocationByRow - 1 < 0 || boat.LocationByColumn - 1 < 0))
                {
                    if (board[boat.LocationByRow - 1, boat.LocationByColumn - 1] == ECellState.Object)
                    {
                        return true;
                    }
                }

                if (!(boat.LocationByRow - 1 < 0 || boat.LocationByColumn + boat.Size > _side - 1))
                {
                    if (board[boat.LocationByRow - 1, boat.LocationByColumn + boat.Size] == ECellState.Object)
                    {
                        return true;
                    }
                }

                if (!(boat.LocationByRow + 1 > _side - 1 || boat.LocationByColumn - 1 < 0))
                {
                    if (board[boat.LocationByRow + 1, boat.LocationByColumn - 1] == ECellState.Object)
                    {
                        return true;
                    }
                }

                if (!(boat.LocationByRow + 1 > _side - 1 || boat.LocationByColumn + boat.Size > -_side - 1))
                {
                    if (board[boat.LocationByRow + 1, boat.LocationByColumn + boat.Size] == ECellState.Object)
                    {
                        return true;
                    }
                }

                return false;
            }

            if (!(boat.LocationByRow - 1 < 0 || boat.LocationByColumn - 1 < 0))
            {
                if (board[boat.LocationByRow - 1, boat.LocationByColumn - 1] == ECellState.Object)
                {
                    return true;
                }
            }

            if (!(boat.LocationByRow - 1 < 0 || boat.LocationByColumn + 1 > _side - 1))
            {
                if (board[boat.LocationByRow - 1, boat.LocationByColumn + 1] == ECellState.Object)
                {
                    return true;
                }
            }

            if (!(boat.LocationByRow + boat.Size > _side - 1 || boat.LocationByColumn - 1 < 0))
            {
                if (board[boat.LocationByRow + boat.Size, boat.LocationByColumn - 1] == ECellState.Object)
                {
                    return true;
                }
            }

            if (!(boat.LocationByRow + boat.Size > _side - 1 || boat.LocationByColumn + 1 > _side - 1))
            {
                if (board[boat.LocationByRow + boat.Size, boat.LocationByColumn + 1] == ECellState.Object)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckBoatSides(GameBoat boat, ECellState[,] board)
        {
            if (boat.IsHor)
            {
                if (!(boat.LocationByColumn - 1 < 0))
                {
                    if (board[boat.LocationByRow, boat.LocationByColumn - 1] == ECellState.Object)
                    {
                        return true;
                    }
                }

                if (!(boat.LocationByColumn + boat.Size >= _side))
                {
                    if (board[boat.LocationByRow, boat.LocationByColumn + boat.Size] == ECellState.Object)
                    {
                        return false;
                    }
                }

                for (var cell = 0; cell < boat.Size; cell++)
                {
                    if (!(boat.LocationByRow - 1 < 0 || boat.LocationByColumn + cell >= _side))
                    {
                        if (board[boat.LocationByRow - 1, boat.LocationByColumn + cell] == ECellState.Object)
                        {
                            return true;
                        }
                    }

                    if (!(boat.LocationByRow + 1 >= _side || boat.LocationByColumn + cell >= _side))
                    {
                        if (board[boat.LocationByRow + 1, boat.LocationByColumn + cell] == ECellState.Object)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            if (!(boat.LocationByRow - 1 < 0))
            {
                if (board[boat.LocationByRow - 1, boat.LocationByColumn] == ECellState.Object)
                {
                    return true;
                }
            }

            if (!(boat.LocationByRow + boat.Size + 1 >= _side))
            {
                if (board[boat.LocationByRow + boat.Size + 1, boat.LocationByColumn] == ECellState.Object)
                {
                    return true;
                }
            }

            for (var cell = 0; cell < boat.Size; cell++)
            {
                if (!(boat.LocationByRow + cell >= _side || boat.LocationByColumn - 1 < 0))
                {
                    if (board[boat.LocationByRow + cell, boat.LocationByColumn - 1] == ECellState.Object)
                    {
                        return true;
                    }
                }

                if (!(boat.LocationByRow + cell >= _side || boat.LocationByColumn + 1 >= _side))
                {
                    if (board[boat.LocationByRow + cell, boat.LocationByColumn + 1] == ECellState.Object)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetSerializedGameState()
        {
            var jsonOption = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var state = new GameState
            {
                NextMoveByFirst = NextMoveByFirst,
                //GameOptions = _gameOptions,
                Side = _playerOneBoard.GetLength(0),
                PlayerOneBoats = _playerOneBoatsArray,
                PlayerTwoBoats = _playerTwoBoatsArray,
                BattleShipLogs = _shipsLogsList.ToArray()
            };
            state.PlayerOneBoard = new ECellState[state.Side][];
            state.PlayerTwoBoard = new ECellState[state.Side][];
            for (var i = 0; i < state.PlayerOneBoard.Length; i++)
            {
                state.PlayerOneBoard[i] = new ECellState[state.Side];
                state.PlayerTwoBoard[i] = new ECellState[state.Side];
            }

            for (var col = 0; col < state.Side; col++)
            {
                for (var row = 0; row < state.Side; row++)
                {
                    state.PlayerOneBoard[col][row] = _playerOneBoard[col, row];
                    state.PlayerTwoBoard[col][row] = _playerTwoBoard[col, row];
                }
            }

            return JsonSerializer.Serialize(state, jsonOption);
        }

        public void SetGameStateFromJson(string jsonString, GameOptions gameOptions)
        {
            var state = JsonSerializer.Deserialize<GameState>(jsonString);

            if (state == null) return;
            NextMoveByFirst = state.NextMoveByFirst;
            _gameOptions = gameOptions;
            _playerOneBoard = new ECellState[state.Side, state.Side];
            _playerTwoBoard = new ECellState[state.Side, state.Side];
            _side = state.Side;
            _playerOneBoatsArray = state.PlayerOneBoats;
            _playerTwoBoatsArray = state.PlayerTwoBoats;
            _shipsLogsList = state.BattleShipLogs.ToList();

            for (var col = 0; col < state.Side; col++)
            {
                for (var row = 0; row < state.Side; row++)
                {
                    _playerOneBoard[col, row] = state.PlayerOneBoard[col][row];
                    _playerTwoBoard[col, row] = state.PlayerTwoBoard[col][row];
                }
            }
        }

        public void MoveForWeb(int attackRow, int attackCol)
        {
            if (EndGame != 0) return;
            if (attackCol >= _side || attackRow >= _side)
            {
                Console.WriteLine("COMMANDER, stop drinking Rum! You can't choose proper coordinates already!");
            }
            else
            {
                var board = _playerOneBoard;
                if (!NextMoveByFirst)
                {
                    board = _playerTwoBoard;
                }

                switch (board[attackCol, attackRow])
                {
                    case ECellState.Empty:
                        board[attackCol, attackRow] = ECellState.Miss;
                        Console.WriteLine("COMMANDER! We hit deep blue ocean! Damn that fog!");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    case ECellState.Wreck:
                        Console.WriteLine("COMMANDER! It is a wreck!");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    case ECellState.Object:
                        board[attackCol, attackRow] = ECellState.Wreck;
                        Console.WriteLine(
                            "COMMANDER! What a nice shot! Seems that I heard armory explosion, but who knows?");
                        switch (_gameOptions.ENextMoveAfterHit)
                        {
                            case ENextMoveAfterHit.OtherPlayer:
                                NextMoveByFirst = !NextMoveByFirst;
                                break;
                            case ENextMoveAfterHit.SamePlayer:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case ECellState.Miss:
                        Console.WriteLine("COMMANDER! Who told that shell doesn't hit the same place twice?");
                        NextMoveByFirst = !NextMoveByFirst;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                WinCheck(board);
            }
        }
    }
}