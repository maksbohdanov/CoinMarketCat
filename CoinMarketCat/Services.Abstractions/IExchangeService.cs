using Domain.Entities;

namespace Services.Abstractions
{
    public interface IExchangeService
    {
        Task<Exchange> GetExchangeById(string exchangeId);
    }
}
