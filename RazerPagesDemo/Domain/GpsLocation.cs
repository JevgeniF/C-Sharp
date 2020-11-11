using System;

namespace Domain
{
    public class GpsLocation
    {
        public int GpsLocationId { get; set; }
        
        public double Lat { get; set; }
        public double Lon { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public int GpsSessionId { get; set; }
        public GpsSession GpsSession { get; set; }
    }
}