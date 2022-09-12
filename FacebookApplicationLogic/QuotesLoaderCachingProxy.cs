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
        private readonly string r_DefaultQuote = "Inspiration does exist, but it must find you working.” —Pablo Picasso";
        private readonly int r_CacheSize = 20;
        private List<string> m_CachedQuotes;
        private QuoteLoader m_QuotesLoader;

        public QuotesLoaderCachingProxy()
        {
            m_QuotesLoader = new QuoteLoader();
            m_CachedQuotes = new List<string>() { r_DefaultQuote };
        }

        public bool GetRandomQuote(out string o_Quote)
        {
            if (m_QuotesLoader.GetRandomQuote(out o_Quote))
            {
                addQuoteToCache(o_Quote);
            }
            else
            {
                o_Quote = getRandomCachedQuote();
            }

            return true;
        }

        private void addQuoteToCache(string i_Quote)
        {
            if (m_CachedQuotes[0] == r_DefaultQuote)
            {
                m_CachedQuotes.Clear();
            }

            m_CachedQuotes.Add(i_Quote);
            if (m_CachedQuotes.Count > r_CacheSize)
            {
                m_CachedQuotes.RemoveAt(0);
            }
        }

        private string getRandomCachedQuote()
        {
            Random rnd = new Random();
            int quoteIndx = rnd.Next(m_CachedQuotes.Count - 1);

            return m_CachedQuotes[quoteIndx];
        }
    }
}
