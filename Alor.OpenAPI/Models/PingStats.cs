namespace Alor.OpenAPI.Models
{
    public class PingStats
    {
        public PingStats(long roundtripTime) { 
            RoundtripTime = roundtripTime;
        }
        public long RoundtripTime { get; }
    }
}