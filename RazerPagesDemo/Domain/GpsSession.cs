using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class GpsSession
    {
        public int GpsSessionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SessionLength { get; set; }
        public int Duration { get; set; }
        
        public ICollection<GpsLocation> GpsLocations { get; set; }
    }
}