using System.Runtime.Serialization;

namespace WebYappe.Models
{
    public class ExchangeRatesPut
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
    }
}
