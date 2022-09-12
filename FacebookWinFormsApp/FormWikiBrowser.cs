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
