using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    public class Artist
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string WikiUrl { get; set; }

        public Artist(string i_Name, string i_ImageUrl)
        {
            Name = i_Name;
            ImageUrl = i_ImageUrl;
            WikiUrl = string.Format("https://en.wikipedia.org/wiki/{0}", i_Name.Replace(' ', '_'));
        }
    }
}
