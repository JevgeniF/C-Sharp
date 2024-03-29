﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain
{
    public class GameOptions
    {
        public int GameOptionsId { get; set; }

        public int BoardSide{ get; set; } = 10; //default classic
        
        public int BoatsCount{ get; set; } = 10; //default classic

        public EBoatsCanTouch EBoatsCanTouch { get; set; } = EBoatsCanTouch.No; //default classic
        public ENextMoveAfterHit ENextMoveAfterHit { get; set; } = ENextMoveAfterHit.SamePlayer; //default classic

        public ICollection<Boat> BoatsList { get; set; } = new List<Boat>();

        public int SavedGameId { get; set; }
        public ICollection<SavedGame> SavedGamesList { get; set; } = new List<SavedGame>();
    }
}