using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using GameLogic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages.Game
{
    public class Index : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly DAL.ApplicationDbContext _context;
        private bool _startGame = false;

        public Index(DAL.ApplicationDbContext context,ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Domain.GameOptions GameOptions { get; set; } = new Domain.GameOptions();
        public Battleships? Battleships { get; set; } = null;

        public bool Error = false;

        public async Task OnGetAsync(int? col, int? row)
        {
            GameOptions = await _context.GameOptions
                .Include(options => options.BoatsList)
                .Include(options => options.SavedGamesList)
                .FirstOrDefaultAsync();
            

            Battleships ??= new Battleships(GameOptions);

            if (!GameOptions.BoatsList.Any())
            {
                ModelState.AddModelError("", "No ships in Harbor! You have to build some first!");
                return;
            }
            /*if (Request.Query.ContainsKey("PlaceManually"))
            {
                for (var index = 0; index < Battleships.GetBoatsArrays().Item1.Count(); index++)
                {
                    if (Request.Query.Count == 0) break;

                    var boatIndex = index + 1;
                    var coll = int.Parse(Request.Query["pOne_col_" + boatIndex]);
                    var roww = int.Parse(Request.Query["pOne_row_" + boatIndex]);
                    var horizontal = Request.Query["pOne_hor_" + boatIndex];

                    if (horizontal == "0")
                    {
                        Battleships.RotateBoat(index); //vertical
                    }

                    Battleships.PlaceBoat(index, coll, roww);

                }

                Battleships.NextFleetDisplacementByFirst = !Battleships.NextFleetDisplacementByFirst;

                for (var index = 0; index < Battleships.GetBoatsArrays().Item2.Count(); index++)
                {
                    if (Request.Query.Count == 0) break;

                    var boatIndex = index + 1;
                    var coll = int.Parse(Request.Query["pTwo_col_" + boatIndex]);
                    var roww = int.Parse(Request.Query["pTwo_row_" + boatIndex]);
                    var horizontal = Request.Query["pTwo_hor_" + boatIndex];

                    if (horizontal == "0")
                    {
                        Battleships.RotateBoat(index);
                    }
                    Battleships.PlaceBoat(index, coll, roww);

                }
                

                Battleships.UpdateBoardWithBoats();
                var boatPlacementViolation =
                    PlacementError(Battleships.GetBoatsArrays().Item2, Battleships.GetBoards().Item2);
                if (boatPlacementViolation)
                {
                    ModelState.AddModelError("", "Something wrong on ship Positions, COMMANDER TWO");
                    Error = true;
                }
                

                Battleships.NextFleetDisplacementByFirst = !Battleships.NextFleetDisplacementByFirst;
                Battleships.UpdateBoardWithBoats();
                boatPlacementViolation = 
                    PlacementError(Battleships.GetBoatsArrays().Item1, Battleships.GetBoards().Item1);
                if (boatPlacementViolation)
                {
                    ModelState.AddModelError("", "Something wrong on ship Positions, COMMANDER ONE");
                    Error = true;
                }

                _startGame = true;
            }
            */

            if (Request.Query.ContainsKey("PlaceRandomly"))
            {
                Battleships.RandomShipsDisplacement(Battleships.GetBoatsArrays().Item1);
                Battleships.NextFleetDisplacementByFirst = !Battleships.NextFleetDisplacementByFirst;
                Battleships.RandomShipsDisplacement(Battleships.GetBoatsArrays().Item2);
                
                _startGame = true;
                
            }

            if (Request.Query.ContainsKey("SaveGame"))
            {
                var serializedGameData = Request.Query["gameState"].ToString();
                
                var savedGame = new SavedGame()
                {
                    SerializedSavedGameData = serializedGameData,
                    SavedGameName = Request.Query["saveName"].ToString()
                };

                GameOptions.SavedGamesList.Add(savedGame);
                _context.GameOptions.Update(GameOptions);
                await _context.SaveChangesAsync();
            }

            if (Request.Query.ContainsKey("loadId"))
            {
                var saveId = int.Parse(Request.Query["loadId"].ToString());
                
                var savedGame = GameOptions.SavedGamesList.First(x => x.SavedGameId == saveId);
                
                
                Battleships.SetGameStateFromJson(savedGame.SerializedSavedGameData, GameOptions);
                Battleships.EndGame = savedGame.EndGame;

                _startGame = true;
                CheckBoards();
            }
            
            if (Request.Query.ContainsKey("ContinueGame"))
            {
                try {
                    var saveGame = GameOptions.SavedGamesList.Last(x => x.SavedGameName.Contains("Move_"));
                    Battleships.SetGameStateFromJson(saveGame.SerializedSavedGameData, GameOptions);
                    Battleships.EndGame = saveGame.EndGame;
                }
                catch
                {
                    ModelState.AddModelError("", "There Is Nothing to Continue, please try later!");
                }
            }
            if (_startGame)
            {
                //when start new game delete old data
                while (GameOptions.SavedGamesList.Any(x => x.SavedGameName.Contains("Move_")))
                {
                    GameOptions.SavedGamesList.Remove(GameOptions.SavedGamesList.Last(x => x.SavedGameName.Contains("Move_")));
                }

                var serializedGameData = Battleships.GetSerializedGameState();
                
                var savedGame = new SavedGame()
                {
                    SerializedSavedGameData = serializedGameData,
                    SavedGameName= "Move_" + DateTime.Now.ToString(CultureInfo.InvariantCulture)
                };

                GameOptions.SavedGamesList.Add(savedGame);
                _context.GameOptions.Update(GameOptions);
                await _context.SaveChangesAsync();
            }
            
            if (GameOptions.SavedGamesList.Any(x=> x.SavedGameName.Contains("Move_")) && !Request.Query.ContainsKey("PlaceBoats"))
            {
                var saveGame = GameOptions.SavedGamesList.Last(x => x.SavedGameName.Contains("Move_"));
                Battleships.SetGameStateFromJson(saveGame.SerializedSavedGameData, GameOptions);
                Battleships.EndGame = saveGame.EndGame;
            }

            if (col != null && row != null)
            {
                if (Battleships.EndGame != 0)
                {
                    //todo finale
                }

                Battleships.MoveForWeb(col.Value, row.Value);

                var savedGame = new SavedGame()
                {
                    SerializedSavedGameData = Battleships.GetSerializedGameState(),
                    SavedGameName = "Move_" + DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    EndGame = Battleships.EndGame
                };

                GameOptions.SavedGamesList.Add(savedGame);
                _context.GameOptions.Update(GameOptions);
                if (Battleships.EndGame != 0)
                {
                    //todo finale
                }

                await _context.SaveChangesAsync();
            }

        }

        private bool PlacementError(GameBoat[] boatArray, ECellState[,] boardArray)
        {
            Debug.Assert(Battleships != null, nameof(Battleships) + " != null");
            return Battleships.CheckIfBoatsOverBattleField(boatArray) ||
                   Battleships.CheckIfBoatsTooClose(boatArray, boardArray) ||
                   Battleships.CheckIfFleetNotAsBigAsRequired(boatArray);
        }

        private void CheckBoards()
        {
            for (var rowIndex = 0; rowIndex < Battleships!.GetSide(); rowIndex++)
            {
                for (var colIndex = 0; colIndex < Battleships.GetSide(); colIndex++)
                {
                    Console.Write($"| {Battleships.GetBoards().Item1[rowIndex, colIndex]} |");
                }
                Console.WriteLine();
                for (var colIndex = 0; colIndex < Battleships.GetSide(); colIndex++)
                {
                    Console.Write($"+---+");
                }
                Console.WriteLine();
                
            }

            Console.WriteLine("======================================================");
            
            for (var rowIndex = 0; rowIndex < Battleships!.GetSide(); rowIndex++)
            {
                for (var colIndex = 0; colIndex < Battleships.GetSide(); colIndex++)
                {
                    Console.Write($"| {Battleships.GetBoards().Item2[rowIndex, colIndex]} |");
                }
                Console.WriteLine();
                for (var colIndex = 0; colIndex < Battleships.GetSide(); colIndex++)
                {
                    Console.Write($"+---+");
                }
                Console.WriteLine();
                
            }

        }
    }
}