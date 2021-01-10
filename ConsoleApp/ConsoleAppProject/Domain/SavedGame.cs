using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SavedGame
    {
        [Key]
        public int SavedGameId { get; set; }

        [MaxLength(512)]
        public string Description { get; set; } = DateTime.Now.ToLongDateString();

        public string SerializedSavedGameData { get; set; } = null!;

        public GameOptions GameOptions { get; set; } = null!;
        public string SavedGameName { get; set; } = null!;

        public bool EndGame = false;
    }
}