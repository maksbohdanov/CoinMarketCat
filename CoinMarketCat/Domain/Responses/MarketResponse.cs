﻿using Domain.Models;

namespace Domain.Responses
{
    public class MarketResponse
    {
        public List<Market> Data { get; set; }
        public long Timestamp { get; set; }
    }
}
