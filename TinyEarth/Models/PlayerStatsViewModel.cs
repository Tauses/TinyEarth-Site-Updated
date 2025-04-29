namespace TinyEarth.Models
{
    public class PlayerStatsViewModel
    {
        public string PlayerName { get; set; }
        public Guid PlayerUUID { get; set; }
        public long Playtime { get; set; } // in milliseconds
        public long LastSeen { get; set; } // Epoch time
        public int Kills { get; set; }
        public double ActivityIndex { get; set; }
    }
}
