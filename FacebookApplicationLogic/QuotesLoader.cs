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
            string url = "https://goquotes-api.herokuapp.com/api/v1/random?count=1";
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            WebResponse webResponse = request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(webStream);
                string body = reader.ReadToEnd();
                quote = QuoteToStringDisplay(jsonToQuoteObj(body));
            }

            return quote;
        }

        private Quote jsonToQuoteObj(string i_jsonInString)
        {
            QuoteWrapper quoteWrapper = JsonSerializer.Deserialize<QuoteWrapper>(i_jsonInString);

            return quoteWrapper.quotes[0];
        }

        public string QuoteToStringDisplay(Quote i_quote)
        {
            return string.Format("{0}{1}-{2}", i_quote.text, System.Environment.NewLine, i_quote.author);
        }
    }
}
