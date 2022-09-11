using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public class QuoteWrapper
    {
        public int status { get; set; }

        public string message { get; set; }

        public int count { get; set; }

        public List<Quote> quotes { get; set; }
    }
}
