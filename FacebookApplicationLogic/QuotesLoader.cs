using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace FacebookApplicationLogic
{
    public class QuoteLoader : IQuotesLoader
    {
        public bool GetRandomQuote(out string o_quote)
        {
            bool isSucceed = true;
            o_quote = null;
            try
            {
                o_quote = getRandomQuoteAsync().Result;
            }
            catch
            {
                isSucceed = false;
            }

            return isSucceed;
        }

        private async Task<string> getRandomQuoteAsync()
        {
            string quote;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://goquotes-api.herokuapp.com/api/v1/random?count=1"),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                quote = QuoteToStringDisplay(jasonToQuoteObj(body));
            }

            return quote;
        }

        private Quote jasonToQuoteObj(string i_jsonInString)
        {
            Quote quote = JsonSerializer.Deserialize<Quote>(i_jsonInString);
            return quote;
        }

        public string QuoteToStringDisplay(Quote i_quote)
        {
            return string.Format("{0}{1}-{2}", i_quote.Text, System.Environment.NewLine, i_quote.Author);
        }
    }
}
