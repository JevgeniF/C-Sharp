using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class GameBoat
    {
        //private static readonly char[] Alpha = "ABCDEFGHIJKLMNOPQRSTX".ToCharArray();
        
        public int GameBoatId { get; set; }

        public string Name { get; set; } = null!;
        public int Size { get; set; }

        public int LocationByColumn { get; set; } = -1; // don't forget to user view starts with 1
        public int LocationByRow { get; set; } = -1; // need to convert to char, to give player trivial understanding of board
        

        public bool IsHor { get; set; } = true; //horizontal, false - vertical 
    }
}