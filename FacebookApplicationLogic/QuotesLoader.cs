using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FacebookApplicationLogic
{
    public class QuotesLoader
    {
        private List<string> m_quotes;

        public QuotesLoader()
        {
            m_quotes = null;
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

        public string getRandomQuote()
        {
            if (m_quotes == null)
            {
                m_quotes = LoadQuotesJson();
            }
            Random randomNumber = new Random();
            int quoteNumber = randomNumber.Next(0, m_quotes.Count - 1);
            return m_quotes[quoteNumber];
        }
    }
}
