using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public delegate void QuoteChagedEventHandler(string i_NewQuote);

    public class QuoteChangesNotifier
    {
        public event QuoteChagedEventHandler QuoteModified;

        protected virtual void OnActionQuoteChanged(string i_ChangedQuote)
        {
            if (QuoteModified != null)
            {
                QuoteModified.Invoke(i_ChangedQuote);
            }
        }

        public void NotifyAll(string i_ChangedQuote)
        {
            OnActionQuoteChanged(i_ChangedQuote);
        }
    }
}
