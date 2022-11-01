namespace Domain.Entities
{
    public class Exchange
    {
        public string ExchangeId { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public double PercentTotalVolume { get; set; }
        public double VolumeUsd { get; set; }
        public string ExchangeUrl { get; set; }
    }
}
