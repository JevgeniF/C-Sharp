using System;
using System.Linq;
using DAL;
using Domain;
using Domain.Enums;
using GameLogic;
using GameUIConsole;
using MenuSystem;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

            // App Header.
            Console.WriteLine("                                _.+-+._");
            Console.WriteLine("                            -==|_.---._|==-");
            Console.WriteLine("                                _\\| |/_");
            Console.WriteLine("                           --==|_.---._|==--");
            Console.WriteLine("                            \\ _/       \\_ /");
            Console.WriteLine("                        \\  _'{           }'_  /");
            Console.WriteLine("                       __'{ !  0   0   0  ! }'__");
            Console.WriteLine("                 ====={                         }=====");
            Console.WriteLine("               _________________________________________");
            Console.WriteLine("              |               .-'  .  '-.   by J.FENKO  |");
            Console.WriteLine("              | '--________-'  +   !   +  '-________--' |");
            Console.WriteLine("               |               !       !               |");
            Console.WriteLine("============================> BATTLESHIPS <=============================");
            Console.WriteLine("");


            var gameOptions = new GameOptions();

            var dbOptions = new DbContextOptions<ApplicationDbContext>();
            using var db = new ApplicationDbContext(dbOptions);
            if (!db.GameOptions.Any())
            {
                db.GameOptions.Add(new GameOptions());
                db.SaveChanges();
            }

            foreach (var gameOption in db.GameOptions.Include(gameOption => gameOption.BoatsList)
                .Include(gameOption => gameOption.SavedGamesList))
            {
                gameOptions = gameOption;
            }

            // Menu options "constructor"
            var menuThemes = new Menu(MenuLevel.Secondary);
            menuThemes.AddMenuItem(new MenuItem("Default", "1", ThemeReset));
            menuThemes.AddMenuItem(new MenuItem("Old Radar", "2", ThemeChanger, "Black", "Green"));

            var menuBoats = new Menu(MenuLevel.Secondary);
            menuBoats.AddMenuItem(new MenuItem("Show available boats", "1", () =>
            {
                ShowBoats(gameOptions);
                return "";
            }));
            menuBoats.AddMenuItem(new MenuItem("Update quantity of boats", "2", () =>
            {
                UpdateBoatQuantity(gameOptions);
                return "";
            }));
            menuBoats.AddMenuItem(new MenuItem("Add new boat to fleet", "3", () =>
            {
                AddBoat(gameOptions);
                return "";
            }));
            menuBoats.AddMenuItem(new MenuItem("Remove boat from fleet", "4", () =>
            {
                RemoveBoat(gameOptions);
                return "";
            }));

            var menuOptions = new Menu(MenuLevel.First);
            menuOptions.AddMenuItem(new MenuItem($"Board Size: default {gameOptions.BoardSide}x{gameOptions.BoardSide}",
                "1", () =>
            {
                BoardSettings(gameOptions);
                return "";
            }));
            menuOptions.AddMenuItem(new MenuItem($"Boats Quantity per Player: default {gameOptions.BoatsCount}",
                "2", () =>
            {
                BoatsQuantitySettings(gameOptions);
                return "";
            }));
            menuOptions.AddMenuItem(new MenuItem($"Boats Nearby Placement Rule: default {GetTouchRuleState(gameOptions)}",
                "3", () =>
            {
                BoatsPlacementSettings(gameOptions);
                return "";
            }));
            menuOptions.AddMenuItem(new MenuItem($"Next Shot after Enemy Boat Hit Rule: default {GetShotRuleState(gameOptions)}",
                "4", () =>
                {
                    ShotAfterHitSettings(gameOptions);
                    return "";
                }));
            
            menuOptions.AddMenuItem(new MenuItem("Build Your Fleet", "6", menuBoats.RunMenu));
            menuOptions.AddMenuItem(new MenuItem("Theme", "5", menuThemes.RunMenu));

            var menu = new Menu(MenuLevel.Root);
            menu.AddMenuItem(new MenuItem("New Game: Player vs Player", "1", () =>
            {
                Game(gameOptions);
                return "";
            }));
            //menu.AddMenuItem(new MenuItem("New Game: Player vs AI", "2", DefaultMenuAction));
            //menu.AddMenuItem(new MenuItem("New Game: AI vs AI", "3", DefaultMenuAction));
            menu.AddMenuItem(new MenuItem("Options", "O", menuOptions.RunMenu));

            menu.RunMenu();

            Console.WriteLine("");

            //App footer.
            Console.WriteLine("===> (c) 2021 <===");
        }

        private static string GetTouchRuleState(GameOptions gameOptions)
        {
            return gameOptions.EBoatsCanTouch switch
            {
                EBoatsCanTouch.Yes => "Allowed",
                EBoatsCanTouch.No => "Not Allowed",
                EBoatsCanTouch.Corner => "Near Corners",
                _ => ""
            };
        }
        
        private static string GetShotRuleState(GameOptions gameOptions)
        {
            return gameOptions.ENextMoveAfterHit switch
            {
                ENextMoveAfterHit.SamePlayer => "Same Player",
                ENextMoveAfterHit.OtherPlayer => "Other Player",
                _ => ""
            };
        }

        private static void DbUpdateOptions(GameOptions gameOptions)
        {
            var dbOptions = new DbContextOptions<ApplicationDbContext>();
            using var db = new ApplicationDbContext(dbOptions);
            db.GameOptions.Add(new GameOptions());
            db.GameOptions.Update(gameOptions);
            db.SaveChanges();
        }

        private static string ThemeReset() //Dedicated action for reversion of color theme back to default console colors.
        {
            Console.ResetColor();
            Console.WriteLine("Default Theme Set!");
            return "";
        }

        private static string ThemeChanger() // Action for Menu "Theme" items in Options/Graphics
        {
            var background = MenuItem.Background;
            var foreground = MenuItem.Foreground;

            ConsoleColor consoleColorBack;
            try

            {
                consoleColorBack = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), background!, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Color!");
                throw;
            }

            Console.BackgroundColor = consoleColorBack;

            ConsoleColor consoleColorFront;
            try

            {
                consoleColorFront = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), foreground!, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Color!");
                throw;
            }

            Console.ForegroundColor = consoleColorFront;
            Console.WriteLine("Theme Changed");
            return "";
        }

        private static void ShowBoats(GameOptions gameOptions)
        {
            if (gameOptions.BoatsList.Count > 0)
            {
                foreach (var boat in gameOptions.BoatsList)
                {
                    Console.WriteLine($"=> {boat}");
                }
            }
            else
            {
                Console.WriteLine("No boats at all!");
            }
        }

        private static void UpdateBoatQuantity(GameOptions gameOptions)
        {
            ShowBoats(gameOptions);
            if (gameOptions.BoatsList.Count == 0) return;
            Console.WriteLine("Please enter type of boat to update quantity:");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (gameOptions.BoatsList.Any(entry => entry.Name == userInput))
                {
                    var name = userInput;
                    Console.WriteLine("Please enter new quantity:");
                    userInput = Console.ReadLine();
                    if (userInput != null)
                    {
                        try
                        {
                            var quantity = Convert.ToInt32(userInput);
                            if (quantity < 0)
                            {
                                Console.WriteLine("Invalid input! Quantity must be 0 or higher...");
                            }
                            else
                            {
                                foreach (var boat in gameOptions.BoatsList)
                                {
                                    if (boat.Name == name)
                                    {
                                        boat.Quantity = quantity;
                                        DbUpdateOptions(gameOptions);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input! Please insert quantity as number...");
                            throw;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please insert quantity as number...");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! No such type in boats database...");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter type...");
            }
        }

        private static void AddBoat(GameOptions gameOptions)
        {
            var boat = new Boat();
            int size;
            int quantity;
            do
            {
                Console.WriteLine("Enter boat type:");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Invalid input! Please enter boat type...");
                    continue;
                }
                if (userInput.Trim() == "")
                {
                    Console.WriteLine("Invalid input! Please enter boat type...");
                    continue;
                }

                if (gameOptions.BoatsList.Count == 0)
                {
                    boat.Name = userInput;
                    break;
                }

                if (gameOptions.BoatsList.Any(entry => entry.Name == userInput))
                {
                    Console.WriteLine("Such boat type already exists!");
                    continue;
                }
                boat.Name = userInput;
                break;
            } while (true);

            do
            {
                Console.WriteLine("Enter boat size:");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Invalid input! Please enter size as number...");
                    continue;
                }
                if (!int.TryParse(userInput.Trim(), out size))
                {
                    Console.WriteLine("Invalid input! Please enter size as number...");
                    continue;
                }
                if (size < 1)
                {
                    Console.WriteLine("Invalid input! Size must be higher than 0...");
                    continue;
                }

                break;
            } while (true);
            boat.Size = size;

            do
            {
                Console.WriteLine("Enter boats quantity:");
                var userInput = Console.ReadLine();
                
                if (userInput == null)
                {
                    Console.WriteLine("Invalid input! Please enter quantity as number...");
                    continue;
                }
                if (!int.TryParse(userInput.Trim(), out quantity))
                {
                    Console.WriteLine("Invalid input! Please enter quantity as number...");
                    continue;
                }
                if (quantity < 0)
                {
                    Console.WriteLine("Invalid input! quantity must be higher than 0 or equal...");
                    continue;
                }

                break;
            } while (true);
            boat.Quantity = quantity;

            Console.WriteLine($"You created the following boat: {boat}");
            do
            {
                Console.WriteLine("Do you want to save this boat? (Y/N)");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Please enter Y or N");
                    continue;
                }

                switch (userInput.ToUpper())
                {
                    case "Y":
                    {
                        gameOptions.BoatsList.Add(boat);
                        DbUpdateOptions(gameOptions);
                        break;
                    }
                    case "N":
                    {
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please enter Y or N");
                        continue;
                    }
                }
                break;
            } while (true);
        }

        private static void RemoveBoat(GameOptions gameOptions)
        {
            ShowBoats(gameOptions);
            if (gameOptions.BoatsList.Count == 0) return;
            string boatType;
            do
            {
                Console.WriteLine("Please enter the type of boat to remove:");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Please enter valid type of boat.");
                    continue;
                }

                if (userInput.Trim() == "")
                {
                    Console.WriteLine("Please enter valid type of boat.");
                    continue;
                }

                boatType = userInput;
                break;
            } while (true);

            foreach (var boat in gameOptions.BoatsList)
            {
                if (boat.Name == boatType)
                {
                    var confirm = false;
                    do
                    {
                        Console.WriteLine($"Are you sure you want to remove {boat}? (Y/N)");
                        var userInput = Console.ReadLine();
                        if (userInput == null)
                        {
                            Console.WriteLine("Please enter Y or N");
                            continue;
                        }

                        switch (userInput.ToUpper())
                        {
                            case "Y":
                            {
                                confirm = true;
                                break;
                            }
                            case "N":
                            {
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Please enter Y or N");
                                continue;
                            }
                        }

                        break;
                    } while (true);

                    if (!confirm) continue;
                    gameOptions.BoatsList.Remove(boat);
                    DbContextOptions<ApplicationDbContext> dbOptions =
                        new DbContextOptions<ApplicationDbContext>();
                    using var db = new ApplicationDbContext(dbOptions);
                    db.Boats.Remove(boat);
                    db.SaveChanges();
                    return;
                }
                else
                {
                    Console.WriteLine("Skip!");
                }
            }
        }

        private static void BoardSettings(GameOptions gameOptions)
        {
            int side;

            do
            {
                Console.WriteLine("What size of board do you prefer? Enter side length (max = 20):");
                var userInput = Console.ReadLine();
                if (userInput == null)
                { 
                    Console.WriteLine("Invalid input. Please insert number from 1 to 20"); 
                    continue;
                }

                if (!int.TryParse(userInput.Trim(), out side))
                {
                    Console.WriteLine("Invalid input. Please insert number from 1 to 20");
                    continue;
                }
                if (side > 20 || side < 1)
                {
                    Console.WriteLine("Invalid input. Please insert number from 1 to 20");
                    continue;
                }
                break;
            } while (true);
            gameOptions.BoardSide = side;
        }

        private static void BoatsQuantitySettings(GameOptions gameOptions)
        {
            int quantity;

            do
            {
                Console.WriteLine("What amount of boats has each player?");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Please input number!");
                    continue;
                }
                if (!int.TryParse(userInput.Trim(), out quantity))
                {
                    Console.WriteLine("Please input number!");
                    continue;
                }
                if (quantity < 1)
                {
                    Console.WriteLine("We can't place have nothing!");
                    continue;
                }
                if (quantity > gameOptions.BoardSide * gameOptions.BoardSide)
                {
                    Console.WriteLine("We can't have more than we have squares on board!");
                    continue;
                }
                break;
            } while (true);
            Console.WriteLine("Well... let's try to place all boats");
            gameOptions.BoatsCount = quantity;
        }

        private static void BoatsPlacementSettings(GameOptions gameOptions)
        {
            EBoatsCanTouch choice;
            do
            {
                Console.WriteLine("Can boats be placed nearby? \n (Y = Yes/ N = No /C = Corners):");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Invalid input! Please enter Y, N or C");
                    continue;
                }

                switch (userInput.ToUpper())
                {
                    case "Y":
                    {
                        choice = EBoatsCanTouch.Yes;
                        break;
                    }
                    case "N":
                    {
                        choice = EBoatsCanTouch.No;
                        break;
                    }
                    case "C":
                    {
                        choice = EBoatsCanTouch.Corner;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid input! Please enter Y, N or C");
                        continue;
                    }
                        
                }

                break;
            } while (true);

            gameOptions.EBoatsCanTouch = choice;
        }

        private static void ShotAfterHitSettings(GameOptions gameOptions)
        {
            ENextMoveAfterHit choice;

            do
            {
                Console.WriteLine("Which shot is next if enemy boat hit? \n (S = Same Player/ O = Other Player):");
                var userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("Please enter S or O");
                    continue;
                }

                switch (userInput.ToUpper())
                {
                    case "S":
                    {
                        choice = ENextMoveAfterHit.SamePlayer;
                        break;
                    }
                    case "O":
                    {
                        choice = ENextMoveAfterHit.OtherPlayer;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please enter S or O");
                        continue;
                    }
                }

                break;
            } while (true);

            gameOptions.ENextMoveAfterHit = choice;
            Console.WriteLine(gameOptions.ENextMoveAfterHit);
        }

        private static void PrepareFleetsForBattle(Battleships battleships)
        {
            var boatsArray = battleships.GetBoatsArrays().Item1;
            Console.WriteLine(
                "COMMANDER ONE, command ships to take positions! \n Or maybe you want me to place ships on positions? (Y/N)");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                switch (userInput.Trim().ToUpper())
                {
                    case "Y":
                    {
                        battleships.RandomShipsDisplacement(boatsArray);
                        battleships.NextFleetDisplacementByFirst = !battleships.NextFleetDisplacementByFirst;
                        break;
                    }
                    case "N":
                    {
                        ManualShipDisplacement(battleships, boatsArray);
                        battleships.NextFleetDisplacementByFirst = !battleships.NextFleetDisplacementByFirst;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Stay focused! Just Y or N!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Can't read you!");
            }

            boatsArray = battleships.GetBoatsArrays().Item2;
            Console.WriteLine(
                "COMMANDER TWO, command ships to take positions! \n Or maybe you want me to place ships on positions? (Y/N)");
            userInput = Console.ReadLine();
            if (userInput != null)
            {
                switch (userInput.Trim().ToUpper())
                {
                    case "Y":
                    {
                        battleships.RandomShipsDisplacement(boatsArray);
                        battleships.NextFleetDisplacementByFirst = !battleships.NextFleetDisplacementByFirst;
                        break;
                    }
                    case "N":
                    {
                        ManualShipDisplacement(battleships, boatsArray);
                        battleships.NextFleetDisplacementByFirst = !battleships.NextFleetDisplacementByFirst;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Stay focused! Just Y or N!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Can't read you!");
            }
        }

        private static void ManualShipDisplacement(Battleships battleships, GameBoat[] boatsArray)
        {
            do
            {
                Console.WriteLine("Select boat? (Y/N)");
                var userInput = Console.ReadLine();

                if (userInput == null)
                {
                    Console.WriteLine("Please enter Y or N");
                    continue;
                }

                if (userInput.ToUpper() == "N")
                {
                    if (battleships.CheckIfFleetNotAsBigAsRequired(boatsArray))
                    {
                        Console.WriteLine("Boats quantity too small or to high, please reallocate!");
                        continue;
                    }

                    if (Battleships.CheckIfBoatsOverBattleField(boatsArray))
                    {
                        Console.WriteLine("Some boats not fully on battlefield, please reallocate!");
                        continue;
                    }

                    var board = battleships.NextFleetDisplacementByFirst
                        ? battleships.GetBoards().Item1
                        : battleships.GetBoards().Item2;
                    if (battleships.CheckIfBoatsTooClose(boatsArray, board))
                    {
                        Console.WriteLine("Boats touch rule violated. Please reallocate!");
                        continue;
                    }

                    break;
                }

                if (userInput.ToUpper() == "Y")
                {
                    var index = 1;
                    foreach (var boat in boatsArray)
                    {
                        Console.WriteLine(
                            $"{index} : {boat.Size} : {boat.IsHor} : @{boat.LocationByRow}, {boat.LocationByColumn}");
                        index++;
                    }

                    int userChoice;
                    do
                    {
                        Console.WriteLine("Please select a boat:");
                        userInput = Console.ReadLine();
                        if (userInput == null)
                        {
                            Console.WriteLine("Please enter number!");
                            continue;
                        }

                        if (!int.TryParse(userInput, out userChoice))
                        {
                            Console.WriteLine("Please enter a number from a list!");
                            continue;
                        }

                        if (userChoice - 1 < 0 && userChoice > boatsArray.Length - 1)
                        {
                            Console.WriteLine("No such position in list!...");
                            continue;
                        }

                        userChoice -= 1;
                        break;
                    } while (true);

                    if ((boatsArray[userChoice].IsHor && boatsArray[userChoice].Size > Battleships.GetBoardSide())
                        || (!boatsArray[userChoice].IsHor &&
                            boatsArray[userChoice].Size > Battleships.GetBoardSide()))
                    {
                        Console.WriteLine("This boat is too big for this board, choose another boat...");
                        continue;
                    }

                    PlaceShipByArrows(battleships, userChoice);
                }
            } while (true);
        }

        private static void PlaceShipByArrows(Battleships battleships, int index)
        {
            var boatsList = battleships.GetBoatsArrays().Item1;
            var board = battleships.GetBoards().Item1;
            if (!battleships.NextFleetDisplacementByFirst)
            {
                boatsList = battleships.GetBoatsArrays().Item2;
                board = battleships.GetBoards().Item2;
            }

            if (boatsList[index].LocationByRow < 0)
            {
                boatsList[index].LocationByRow = 0;
                boatsList[index].LocationByColumn = 0;
                battleships.UpdateBoardWithBoats();
                ConsoleUi.DrawBoard(board, true);
            }

            do
            {
                Console.WriteLine(
                    "Command Station activated! Move ships by arrows, rotate by R, delete by X, leave at location by SpaceBar");
                var keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.LeftArrow)
                {
                    battleships.PlaceBoat(index, boatsList[index].LocationByRow - 1, boatsList[index].LocationByColumn);
                }

                if (keyInput.Key == ConsoleKey.RightArrow)
                {
                    battleships.PlaceBoat(index, boatsList[index].LocationByRow + 1, boatsList[index].LocationByColumn);
                }

                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    battleships.PlaceBoat(index, boatsList[index].LocationByRow, boatsList[index].LocationByColumn - 1);
                }

                if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    battleships.PlaceBoat(index, boatsList[index].LocationByRow, boatsList[index].LocationByColumn + 1);
                }

                if (keyInput.KeyChar == 'r')
                {
                    battleships.RotateBoat(index);
                }

                if (keyInput.KeyChar == 'x')
                {
                    battleships.PlaceBoat(index, -1, -1);
                }
                
                battleships.UpdateBoardWithBoats();
                board = battleships.NextFleetDisplacementByFirst ? battleships.GetBoards().Item1 : battleships.GetBoards().Item2;
                ConsoleUi.DrawBoard(board, true);
                
                if (keyInput.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            } while (true);
        }

        private static string Game(GameOptions gameOptions) //Default action for game
        {

            if (gameOptions.BoatsList.Count == 0)
            {
                Console.WriteLine(
                    "(o _ o)! Sir! Have you built a fleet? There are no boats in harbor! Please proceed to Options...");
                return "";
            }
            else if (gameOptions.BoatsList.Sum(boat => boat.Quantity) < gameOptions.BoatsCount)
            {
                Console.WriteLine(
                    "(o _ o)! Sir! The fleet is to small! We need more ships! Please proceed to Options...");
                return "";
            }

            var game = new Battleships(gameOptions);
            string userChoice;

            EndPoint:
            Console.WriteLine("Would you like to load previous game? (Y/N)");
            var option = Console.ReadLine()?.ToUpper().Trim();
            if (option == "Y")
            {
                LoadGameAction(game, gameOptions);
            }
            else if (option != "N" && option != "Y")
            {
                Console.WriteLine("No such Option");
                goto EndPoint;
            }

            PrepareFleetsForBattle(game);

            do
            {
                if (game.NextMoveByFirst)
                {
                    Console.WriteLine("( O _ O )/ !...");
                    Console.WriteLine(
                        "COMMANDER ONE! Sonar detected ENEMY ships somewhere in the fog. We must attack!");
                }
                else
                {
                    Console.WriteLine("( O _ O')/ !...");
                    Console.WriteLine(
                        "ALARM!!! COMMANDER TWO! We've been attacked by ENEMY! All crew to the battle stations!");
                }

                var menu = new Menu(MenuLevel.Game);
                menu.AddMenuItem(new MenuItem("Engage weapons system", "P",
                    () =>
                    {
                        if (game.EndGame == 1)
                        { //todo ascii
                            return "";
                        }
                        ConsoleUi.DrawBoards(game.GetBoards(), game.NextMoveByFirst);
                        var target = GetMoveCoordinates();
                        game.RecordToLog(target);
                        game.MakeAMove(target);
                        
                        //Console.Clear();
                        if (game.NextMoveByFirst)
                        {
                            Console.WriteLine("( O _ O )/ !...");
                            Console.WriteLine(
                                "COMMANDER ONE! Sonar detected ENEMY ships somewhere in the fog. We must attack!");
                        }
                        else
                        {
                            Console.WriteLine("( O _ O')/ !...");
                            Console.WriteLine(
                                "ALARM!!! COMMANDER TWO! We've been attacked by ENEMY! All crew to the battle stations!");
                        }

                        return "";

                    }));
                menu.AddMenuItem(new MenuItem("Save Game", "S", () =>
                {
                    SaveGameAction(game, gameOptions);
                    return "";
                }));
                menu.AddMenuItem(new MenuItem("Load Game", "L", () =>
                {
                    LoadGameAction(game, gameOptions);
                    return "";
                }));
                menu.AddMenuItem(new MenuItem("Don't even go there. It's cheaters theme!", "C", () =>
                {
                    ReplayMoves(game);
                    return "";
                }));
                userChoice = menu.RunMenu();
            } while (userChoice != "E");

            return "";
        }
        
        private static string GetMoveCoordinates() // Get coordinates of user move
        {
            Console.WriteLine("Indicate a square for attack, Commander!");
            var userValue = Console.ReadLine()?.ToUpper().Trim() ?? "";
            return userValue;
        }

        private static string LoadGameAction(Battleships battleships, GameOptions gameOptions)
        {
            /*
                       var files = Directory.EnumerateFiles(".", "save_*.json").ToList();
                       for (var i = 0; i < files.Count; i++) Console.WriteLine($"{i} - {files[i]}");
                       Console.WriteLine("Enter SaveFile Number:");
                       var number = Console.ReadLine();
                       number = number?.Trim();
                       if (!string.IsNullOrEmpty(number))
                       { 
                           var fileNumber = files.Count + 1; 
                           var success = number != "" && int.TryParse(number, out fileNumber); 
                           if (success) 
                           { 
                               if (fileNumber >= 0 && files.Count - 1 >= fileNumber) 
                               { 
                                   var fileName = files[fileNumber]; 
                                   var jsonString = File.ReadAllText(fileName); 
                                   game.SetGameStateFromJson(jsonString);
                               }
                               else 
                               { 
                                   Console.WriteLine("Save not found!"); 
                                   LoadGameAction(game);
                               }
                           }
                       }
                       else
                       {
                           Console.WriteLine("Save not found!");
                           LoadGameAction(game);
                       }
                       */
            DbContextOptions<ApplicationDbContext> dbOptions = new DbContextOptions<ApplicationDbContext>();
            using var db = new ApplicationDbContext(dbOptions);

            var savedGamesList = db.SavedGames.ToList();
            if (savedGamesList.Count == 0)
            {
                Console.WriteLine("No saved games found");
                return "";
            }

            for (var index = 1; index < savedGamesList.Count; index++)
            {
                    Console.WriteLine($"{index}. = {savedGamesList[index].SavedGameName} = {savedGamesList[index].DateTime}");
            }
            Console.WriteLine("R = return without load");
            Console.WriteLine(""); 
            Console.WriteLine("Please select Saved Game...");
            var userInput = Console.ReadLine();

            if (userInput != null)
            {
                if (userInput == "R")
                {
                    ConsoleUi.DrawBoards(battleships.GetBoards(), battleships.NextMoveByFirst);
                    return "";
                }

                try
                {
                    var userChoice = Convert.ToInt32(userInput.Trim());
                    if (userChoice - 1 < 0 || userChoice - 1 > savedGamesList.Count - 1)
                    {
                        Console.WriteLine($"Please input number in range 1...{savedGamesList.Count}");
                        return "";
                    }

                    var saveGame = savedGamesList[userChoice];
                    var jsonString = saveGame.SerializedSavedGameData;
                    battleships.SetGameStateFromJson(jsonString, gameOptions);
                    ConsoleUi.DrawBoards(battleships.GetBoards(), battleships.NextMoveByFirst);
                    return "";
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input number!");
                    return "";
                }
            }
            
            Console.WriteLine("Please make a choice!");
            return "";
                    
        }

        private static string SaveGameAction(Battleships battleships, GameOptions gameOptions)
        {
            /*
                     var defaultName = "save_" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
                     Console.WriteLine($"File name ({defaultName}):");
                     var fileName = "";
                     var name = Console.ReadLine();
                     if (string.IsNullOrWhiteSpace(name))
                     {
                         fileName = defaultName;
                     }
                     else
                     {
                         fileName = "save_" + name + ".json";
                     }
         
                     var serializedGame = game.GetSerializedGameState();
                     File.WriteAllText(fileName, serializedGame);
                     return "";
                     */
            var serializedGameState = battleships.GetSerializedGameState();

            DbContextOptions<ApplicationDbContext> dbOptions = new DbContextOptions<ApplicationDbContext>();
            using var db = new ApplicationDbContext(dbOptions);

            var savedGameName = "";

            do
            {
                Console.WriteLine("Please Enter Name for your Game...");
                Console.WriteLine("R = return");
                Console.Write("");
                var userInput = Console.ReadLine();

                if (userInput != null)
                {
                    savedGameName = userInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Name can't be blank!");
                }

            } while (true);

            if (savedGameName.Trim().ToUpper() == "R")
            {
                ConsoleUi.DrawBoards(battleships.GetBoards(), battleships.NextMoveByFirst);
                return "";
            }

            var savedGame = new SavedGame()
            {
                SerializedSavedGameData = serializedGameState,
                SavedGameName = savedGameName,
            };

            gameOptions.SavedGamesList.Add(savedGame);
            db.GameOptions.Update(gameOptions);
            db.SaveChanges();

            return "";
        }

        private static string ReplayMoves(Battleships battleships)
        {
            var movesCounter = 1;
            Console.WriteLine($"0 = Start From Beginning.");
            foreach (var log in battleships.GetLog())
            {
                Console.WriteLine($"{movesCounter} = Move: {log.move}");
                movesCounter++;
            }
            
            Console.WriteLine("Please enter the move number. Remember: Cheating is EVIL!");
            Console.WriteLine("R = return");
            Console.WriteLine("");
            int userChoice;
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput.Trim().ToUpper() == "R")
                {
                    ConsoleUi.DrawBoards(battleships.GetBoards(), battleships.NextMoveByFirst);
                    return "";
                }

                try
                {
                    userChoice = Convert.ToInt32(userInput);
                    if (userChoice < 0 || userChoice > movesCounter)
                    {
                        Console.WriteLine($"Please enter number in rage 0...{movesCounter}");
                    }
                    else
                    {
                        battleships.Cheating(userChoice - 1);
                        ConsoleUi.DrawBoards(battleships.GetBoards(), battleships.NextMoveByFirst);
                        return "";
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number!");
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Please make your choice!");
            }
            return "";
        }
        
        private static string DefaultMenuAction() //Default action for not implemented menu functions
        {
            Console.WriteLine("Not implemented yet.");
            return "";
        }
    }
}