using Domain.Entities;

namespace Domain.Responses
{
    public class HistoryDataResponse
    {
        public List<HistoryData> Data { get; set; }
        public long Timestamp { get; set; }
    }
}
