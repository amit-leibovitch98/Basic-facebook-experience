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

        public string NewQuote { get; set; }

        public QuoteChanges(string i_NewQuote)
        {
            NewQuote = i_NewQuote;
        }

        protected virtual void OnActionQuoteChanged()
        {
            if (QuoteIsChanged != null)
            {
                QuoteIsChanged.Invoke(NewQuote);
            }
        }

        public void NotifyAll()
        {
            OnActionQuoteChanged();
        }
    }
}
