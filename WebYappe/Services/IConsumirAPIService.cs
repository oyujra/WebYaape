using WebYappe.Models;

namespace WebYappe.Services
{
    public interface IConsumirAPIService
    {
        Task<string> GenerateToken();
        Task<List<ExchangeRates>> ExchangeRates(string token);
        Task<ExchangeRates> PutExchangeRates(ExchangeRatesPut exchangeRatesPut, string token);
    }
}
