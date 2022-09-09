using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Net;

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
                o_quote = getQuote();
            }
            catch
            {
                isSucceed = false;
            }

            return isSucceed;
        }

        private string getQuote()
        {
            string quote;
            /*
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
            */
            string url = "https://goquotes-api.herokuapp.com/api/v1/random?count=1";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            using (var webStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(webStream);
                string body = reader.ReadToEnd();
                quote = QuoteToStringDisplay(jasonToQuoteObj(body));
            }

            return quote;
        }

        private Quote jasonToQuoteObj(string i_jsonInString)
        {
            Quote quote;
            QuoteWrapper quoteWrapper = JsonSerializer.Deserialize<QuoteWrapper>(i_jsonInString);
            //DELETEEEEEEEEEEEEEEEEEE
            //throw new NotImplementedException();
            //DELETEEEEEEEEEEEEEEEEEE
            return quoteWrapper.quotes[0];
        }

        public string QuoteToStringDisplay(Quote i_quote)
        {
            return string.Format("{0}{1}-{2}", i_quote.text, System.Environment.NewLine, i_quote.author);
        }
    }
}
