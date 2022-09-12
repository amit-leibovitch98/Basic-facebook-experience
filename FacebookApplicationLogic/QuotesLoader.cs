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
        public bool GetRandomQuote(out string o_Quote)
        {
            bool isSucceed = true;
            o_Quote = null;
            try
            {
                o_Quote = getQuote();
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
            WebResponse webResponse;
            WebRequest request = WebRequest.Create(url);

            request.Method = "GET";
            webResponse = request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(webStream);
                string body = reader.ReadToEnd();
                quote = QuoteToStringDisplay(jsonToQuoteObj(body));
            }

            return quote;
        }

        private Quote jsonToQuoteObj(string i_JsonInString)
        {
            QuoteWrapper quoteWrapper = JsonSerializer.Deserialize<QuoteWrapper>(i_JsonInString);

            return quoteWrapper.quotes[0];
        }

        public string QuoteToStringDisplay(Quote i_Quote)
        {
            return string.Format("{0}{1}-{2}", i_Quote.text, System.Environment.NewLine, i_Quote.author);
        }
    }
}
