using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public delegate void QuoteChagedEventHandler(string i_NewQuote);

    public class QuoteChanges
    {
        public event QuoteChagedEventHandler QuoteIsChaged;

        private string m_NewQuote;

        public QuoteChanges(string i_NewQuote)
        {
            m_NewQuote = i_NewQuote;
        }

        protected virtual void OnActionQuoteChaged()
        {
            if (QuoteIsChaged != null)
            {
                QuoteIsChaged.Invoke(m_NewQuote);
            }
        }

        public void NotifyAll()
        {
            OnActionQuoteChaged();
        }
    }
}
