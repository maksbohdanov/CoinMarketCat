using Domain.Entities;

namespace Domain.Responses
{
    public class AssetsByIdResponse
    {
        
        public Asset Data { get; set; }
        public string Timestamp { get; set; }
    }
}
