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
        private int m_quoteNumber;
        private List<string> m_quotes;

        public QuotesLoader()
        {
            m_quotes = LoadJson();
            Random quoteNumber = new Random();
            m_quoteNumber = quoteNumber.Next(0, m_quotes.Count - 1);
        }

        public List<string> LoadJson()
        {
            string json = null;
            using (StreamReader r = new StreamReader("Quotes.json"))
            {
                json = r.ReadToEnd();
            }

            if (json == null)
            {
                throw new FileLoadException("Fail to load quotes!");
            }

            return JsonConvert.DeserializeObject<List<string>>(json);

        }

        public string getRandomQuote()
        {
            List<string> quotesList = LoadJson();
            return quotesList[m_quoteNumber];
        }
    }
}
