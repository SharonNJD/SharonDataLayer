using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CurrencyModel;
using static CurrencyModel.Currency;
using System.Net.Http;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace CurrencyBL
{
    public class CurrenciesManager
    {
        private List<Currency> ParseJsyon() { return null; }
        private static string apiUrl = "https://boi.org.il/PublicApi/GetExchangeRates";
        private static string[] symbols = new string[] {"USD - $", "EUR - €", "GBP - £", "JPY - ¥", "CHF - ₣",
                                                        "INR - ₹", "KWD - د.ك", "AED - د.إ", "SAR - ﷼", "DEM - ₻",
                                                        "RUB - ₽","GEL - ₾","TRY - ₺","AZN - ₼","KZT - ₸","UAH - ₴",
                                                        "XRE - ₷", "THB - ฿", "KRW - 원", "VND - ₫", "MNT - ₮", "GRD - ₯",
                                                        "PHP - ₱", "AUD - ₳", "GHS - ₵", "PYG - ₲","ILS - ₪", "GBP - ₤"};
        public string GetSymbolByKey(string key)
        {
            foreach (string entry in symbols)
            {
                string[] parts = entry.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && parts[0].Trim() == key)
                {
                    return parts[1].Trim();
                }
            }
            // If the currency name is not found, return null or throw an exception as per your requirement.
            return null; // You can modify this part if you want to handle not found case differently.
        }
        public CurrencyList GetCurrencyList()
        {
            CurrencyList list = new CurrencyList();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send GET request synchronously
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as string
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Parse JSON response
                        JObject data = JObject.Parse(jsonResponse);

                        // Extract and process items
                        JArray itemsArray = (JArray)data["exchangeRates"];
                        foreach (JToken item in itemsArray)
                        {
                            Currency currency = new Currency()
                            {
                                Key = item["key"].ToString(),
                                Symbol = GetSymbolByKey(item["key"].ToString()),
                                Rate = double.Parse(item["currentExchangeRate"].ToString()),
                                Change = double.Parse(item["currentChange"].ToString()),
                                Unit = int.Parse(item["unit"].ToString())
                            };
                            list.Add(currency);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return null;
                }
                return list;
            }
        }

        public double Convert(Currency source, Currency target, double amount) { return ((source.Rate / source.Unit) / (target.Rate / target.Unit)) * amount; }
    }
}