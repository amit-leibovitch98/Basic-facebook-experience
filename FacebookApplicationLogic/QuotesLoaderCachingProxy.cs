using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public class QuotesLoaderCachingProxy : IQuotesLoader
    {
        //private List<Quote> m_CachedQuotes;
        private readonly string m_DefaultQuote = "Inspiration does exist, but it must find you working.” —Pablo Picasso";
        private readonly int m_CacheSize = 20;
        private List<string> m_CachedQuotes;
        private QuoteLoader m_QuotesLoader;

        public QuotesLoaderCachingProxy()
        {
            m_QuotesLoader = new QuoteLoader();
            m_CachedQuotes = new List<string>() { m_DefaultQuote };
            //LoadQuotesToCashIfNeeded();
        }

        /*public void LoadQuotesToCashIfNeeded()
        {
            string fileContent;
            System.IO.FileStream quotesFile;
            string filePath = "resources/CashedQuotes.json";
            if (!File.Exists(filePath))
            {
                quotesFile = System.IO.File.Create(filePath);
                quotesFile.Close();
            }

            using (StreamReader r = new StreamReader(filePath))
            {
                fileContent = r.ReadToEnd();
                if (fileContent == string.Empty)
                {
                    r.Close();
                    LoadQuotesToCache(filePath);
                }
            }
        }

        public void LoadQuotesToCache(string i_filePath)
        {
            string url = "https://goquotes-api.herokuapp.com/api/v1/random?count=20";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            using (var webStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(webStream);
                string body = reader.ReadToEnd();
                File.WriteAllText(i_filePath, body);
                reader.Close();
            }
        }

        public void LoadQuotesFromJson()
        {
            string json = null;
            if (!File.Exists("resources/CashedQuotes.json"))
            {
                throw new FileLoadException("Failed to load quotes!");
            }

            using (StreamReader r = new StreamReader("resources/CashedQuotes.json"))
            {
                json = r.ReadToEnd();
            }

            if (json == null)
            {
                throw new FileLoadException("Failed to load quotes!");
            }

            QuoteWrapper quoteWrapper = JsonSerializer.Deserialize<QuoteWrapper>(json);
            m_CachedQuotes = quoteWrapper.quotes;
        }*/

        public bool GetRandomQuote(out string o_quote)
        {
            if (m_QuotesLoader.GetRandomQuote(out o_quote))
            {
                m_CachedQuotes.Add(o_quote);
                if (m_CachedQuotes.Count > m_CacheSize)
                {
                    m_CachedQuotes.RemoveAt(0);
                }
            }
            else
            {
                //LoadQuotesFromJson();
                Random rnd = new Random();
                int quoteIndx = rnd.Next(m_CachedQuotes.Count - 1);
                //o_quote = m_QuotesLoader.QuoteToStringDisplay(m_CachedQuotes[quoteIndx]);
                o_quote = m_CachedQuotes[quoteIndx];
            }

            return true;
        }
    }
}
