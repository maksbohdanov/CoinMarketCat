using Domain.Models;

namespace Domain.Responses
{
    public class AssetsResponse
    {
        
        public List<Asset> Data { get; set; }
        public string Timestamp { get; set; }
    }
}
