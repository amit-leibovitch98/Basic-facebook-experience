using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace FacebookApplicationLogic
{
    public class QuotesLoader
    {
        private List<string> m_Quotes;

        public QuotesLoader()
        {
            m_Quotes = null;
        }

        public List<string> LoadQuotesJson()
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

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        public string GetRandomQuote()
        {
            if (m_Quotes == null)
            {
                m_Quotes = LoadQuotesJson();
            }

            Random randomNumber = new Random();
            int quoteNumber = randomNumber.Next(0, m_Quotes.Count - 1);
            return m_Quotes[quoteNumber];
        }
    }
}
