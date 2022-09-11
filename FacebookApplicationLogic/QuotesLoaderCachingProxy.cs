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
        private readonly string m_DefaultQuote = "Inspiration does exist, but it must find you working.” —Pablo Picasso";
        private readonly int m_CacheSize = 20;
        private List<string> m_CachedQuotes;
        private QuoteLoader m_QuotesLoader;

        public QuotesLoaderCachingProxy()
        {
            m_QuotesLoader = new QuoteLoader();
            m_CachedQuotes = new List<string>() { m_DefaultQuote };
        }

        public bool GetRandomQuote(out string o_quote)
        {
            if (m_QuotesLoader.GetRandomQuote(out o_quote))
            {
                if (m_CachedQuotes[0] == m_DefaultQuote)
                {
                    m_CachedQuotes.Clear();
                }

                m_CachedQuotes.Add(o_quote);
                if (m_CachedQuotes.Count > m_CacheSize)
                {
                    m_CachedQuotes.RemoveAt(0);
                }
            }
            else
            {
                Random rnd = new Random();
                int quoteIndx = rnd.Next(m_CachedQuotes.Count - 1);
                o_quote = m_CachedQuotes[quoteIndx];
            }

            return true;
        }
    }
}
