using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public partial class FormShareQuote : Form
    {
        private FacebookLogicService m_FacebookLogicService;

        public FormShareQuote(FacebookLogicService i_FacebookLogicService)
        {
            InitializeComponent();
            m_FacebookLogicService = i_FacebookLogicService;
            textBoxToPost.Text = m_FacebookLogicService.GetQuote();
        }

        private void buttonShareQuote_Click(object sender, EventArgs e)
        {
            try
            {
                m_FacebookLogicService.PostStatus(textBoxToPost.Text);
            }
            catch(Facebook.FacebookOAuthException)
            {
                MessageBox.Show(string.Format("Can't post {0} Due to server error :(",Environment.NewLine), "Cant post", MessageBoxButtons.OK);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
