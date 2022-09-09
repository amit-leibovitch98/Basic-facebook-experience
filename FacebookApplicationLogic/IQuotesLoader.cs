using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public interface IQuotesLoader
    {
        bool GetRandomQuote(out string o_quote);
    }
}
