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
        public FormWikiBrowser(string i_WikiUrl)
        {
            InitializeComponent();
            webBrowserLikedArtists.Url = new System.Uri(i_WikiUrl);
        }
    }
}
