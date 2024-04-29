using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebYappe.Models;

namespace WebYappe.Services
{
    public class ConsumirAPIService : IConsumirAPIService
    {
        private string path = "http://localhost:3519/ServicioREST.svc/";
        //private string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im95dWpyYSIsIm5iZiI6MTcxNDM2MTc1OSwiZXhwIjoxNzE0MzY1MzU5LCJpYXQiOjE3MTQzNjE3NTl9.wyRbpk5y99XI950JROZAFdEK69Fi8usNQ5uSsVTIFFQ";

        public async Task<ExchangeRates> PutExchangeRates(ExchangeRatesPut exchangeRatesPut, string token)
        {
            HttpClient _httpClient;
            ExchangeRates result = new ExchangeRates();
            string url = path + $"ExchangeRates";

            // Serializa los datos de ExchangeRatesPut a JSON y crea el contenido de la solicitud
            string putData = JsonConvert.SerializeObject(exchangeRatesPut);
            HttpContent requestContent = new StringContent(putData, Encoding.UTF8, "application/json");

            // Crea una instancia de HttpClient (debe ser compartida y reutilizable)
            using (_httpClient = new HttpClient())
            {
                try
                {
                    
                    // Agrega el encabezado de autorización Bearer
                    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    _httpClient.DefaultRequestHeaders.Add("AuthorizationX", "Bearer " + token);

                    // Realiza la solicitud PUT a la API con el contenido y espera la respuesta
                    HttpResponseMessage response = await _httpClient.PutAsync(new Uri(url), requestContent);

                    // Verifica si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Procesa los datos recibidos como desees
                        result = JsonConvert.DeserializeObject<ExchangeRates>(responseBody);
                    }
                    else
                    {
                        // La solicitud no fue exitosa, establece el resultado como nulo
                        result = null;
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier error que ocurra durante la solicitud
                    Console.WriteLine($"Error al realizar la solicitud PUT a la API: {ex.Message}");
                    result = null;
                }
            }

            return result;
        }

        public async Task<string> GenerateToken()
        {
            HttpClient _httpClient;
            string result = "";
            string url = path + $"GenerateToken";

            // Serializa los datos de ExchangeRatesPut a JSON y crea el contenido de la solicitud
            string putData = "";
            HttpContent requestContent = new StringContent(putData, Encoding.UTF8, "application/json");

            // Crea una instancia de HttpClient (debe ser compartida y reutilizable)
            using (_httpClient = new HttpClient())
            {
                try
                {
                    // Realiza la solicitud PUT a la API con el contenido y espera la respuesta
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(url));

                    // Verifica si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();
                        responseBody = responseBody.Trim('"');
                        // Procesa los datos recibidos como desees
                        result = responseBody;
                    }
                    else
                    {
                        // La solicitud no fue exitosa, establece el resultado como nulo
                        result = "";
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier error que ocurra durante la solicitud
                    Console.WriteLine($"Error al realizar la solicitud PUT a la API: {ex.Message}");
                    result = "";
                }
            }

            return result;
        }
        public async Task<List<ExchangeRates>> ExchangeRates(string token) {
            HttpClient _httpClient;
            List<ExchangeRates> result = new List<ExchangeRates>();
            string url = path + $"ExchangeRates";

            // Serializa los datos de ExchangeRatesPut a JSON y crea el contenido de la solicitud
            // Crea una instancia de HttpClient (debe ser compartida y reutilizable)
            using (_httpClient = new HttpClient())
            {
                try
                {
                    // Agrega el encabezado de autorización Bearer
                    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    _httpClient.DefaultRequestHeaders.Add("AuthorizationX", "Bearer " + token);

                    // Realiza la solicitud PUT a la API con el contenido y espera la respuesta
                    HttpResponseMessage response = await _httpClient.GetAsync(new Uri(url));

                    // Verifica si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Procesa los datos recibidos como desees
                        result = JsonConvert.DeserializeObject<List<ExchangeRates>>(responseBody);
                    }
                    else
                    {
                        // La solicitud no fue exitosa, establece el resultado como nulo
                        result = null;
                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier error que ocurra durante la solicitud
                    Console.WriteLine($"Error al realizar la solicitud PUT a la API: {ex.Message}");
                    result = null;
                }
            }

            return result;
        }
    }
}
