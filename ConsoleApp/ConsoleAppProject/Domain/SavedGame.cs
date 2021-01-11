using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SavedGame
    {
        public int SavedGameId { get; set; }

        [MaxLength(512)]
        public string DateTime { get; set; } = System.DateTime.Now.ToLongDateString();

        public string SerializedSavedGameData { get; set; } = null!;

        public GameOptions GameOptions { get; set; } = null!;
        public string SavedGameName { get; set; } = null!;

        public int EndGame = 0;
    }
}