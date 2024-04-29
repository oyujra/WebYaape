namespace WebYappe.Models
{
    public class ExchangeRates
    {
        public int Id { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountWithExchangeRate { get; set; }
    }
}
