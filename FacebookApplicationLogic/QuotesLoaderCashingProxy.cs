using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public class QuotesLoaderCashingProxy : IQuotesLoader
    {
        public List<Quote> CashedQuotes { get; set; }

        public QuoteLoader quotesLoader { get; set; }

        public QuotesLoaderCashingProxy()
        {
            quotesLoader = new QuoteLoader();
            LoadQuotesToCashIfNeeded();
        }

        public void LoadQuotesToCashIfNeeded()
        {
            string fileContent;
            string filePath = "resources/Quotes.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                System.IO.FileStream quotesFile;
                if (!File.Exists(filePath))
                {
                    quotesFile = System.IO.File.Create(filePath);
                }

                fileContent = r.ReadToEnd();
                if (fileContent == null)
                {
                    LoadQuotesToCash(filePath);
                }
            }
        }

        public async void LoadQuotesToCash(string i_filePath)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://goquotes-api.herokuapp.com/api/v1/random?count=20"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                using (StreamReader r = new StreamReader(i_filePath))
                {
                    File.WriteAllText(i_filePath, body);
                }
            }
        }

        public void LoadQuotesFromJson()
        {
            string json = null;
            if (!File.Exists("resources/Quotes.json"))
            {
                throw new FileLoadException("Failed to load quotes!");
            }

            using (StreamReader r = new StreamReader("resources/Quotes.json"))
            {
                json = r.ReadToEnd();
            }

            if (json == null)
            {
                throw new FileLoadException("Failed to load quotes!");
            }

            CashedQuotes = JsonSerializer.Deserialize<List<Quote>>(json);
        }

        public bool GetRandomQuote(out string o_quote)
        {
            if(!quotesLoader.GetRandomQuote(out o_quote))
            {
                LoadQuotesFromJson();
                Random rnd = new Random();
                int quoteIndx = rnd.Next(CashedQuotes.Count - 1);
                o_quote = quotesLoader.QuoteToStringDisplay(CashedQuotes[quoteIndx]);
            }

            return true;
        }
    }
}
