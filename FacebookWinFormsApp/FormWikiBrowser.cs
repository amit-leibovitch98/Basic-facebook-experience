using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormWikiBrowser : Form
    {
        public FormWikiBrowser(string i_artistsName)
        {
            InitializeComponent();
            webBrowserLikedArtists.Url = new System.Uri(string.Format("https://en.wikipedia.org/wiki/{0}", i_artistsName));
        }
    }
}
