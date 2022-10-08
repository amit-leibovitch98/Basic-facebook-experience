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
        public event QuoteChagedEventHandler QuoteIsChanged;

        private string m_NewQuote;

        public QuoteChanges(string i_NewQuote)
        {
            m_NewQuote = i_NewQuote;
        }

        protected virtual void OnActionQuoteChanged()
        {
            if (QuoteIsChanged != null)
            {
                QuoteIsChanged.Invoke(m_NewQuote);
            }
        }

        public void NotifyAll()
        {
            OnActionQuoteChanged();
        }
    }
}
