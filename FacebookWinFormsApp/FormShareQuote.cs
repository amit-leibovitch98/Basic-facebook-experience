using System;
using System.Windows.Forms;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public partial class FormShareQuote : Form
    {
        private FacebookLogicService m_FacebookLogicService;
        private QuoteChanges m_QuoteChanges;

        public FormShareQuote()
        {
            InitializeComponent();
            m_FacebookLogicService = FacebookLogicService.Instance;
            textBoxToPost.Text = m_FacebookLogicService.GetQuote();
            m_QuoteChanges = new QuoteChanges(textBoxToPost.Text);
            m_QuoteChanges.QuoteIsChaged += m_FacebookLogicService.ChangeQuote;
        }

        private void buttonShareQuote_Click(object sender, EventArgs e)
        {
            bool dontPost = false;
            if(m_FacebookLogicService.GetQuote() != textBoxToPost.Text)
            {
                m_QuoteChanges.NotifyAll();
                DialogResult dialogResult = MessageBox.Show(string.Format("notice! {0} Since youv'e ultered the quote, we added a disclouser to your post. {1} It will now look like this: {2} {3} Are you still ant to post it?", Environment.NewLine, Environment.NewLine, m_FacebookLogicService.GetQuote(), Environment.NewLine), "Notice!", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.No))
                {
                    Close();
                    dontPost = true;
                }
            }

            if (dontPost == false)
            {
                try
                {
                    m_FacebookLogicService.PostStatus(textBoxToPost.Text);
                }
                catch (Facebook.FacebookOAuthException)
                {
                    MessageBox.Show(string.Format("Can't post {0} Due to server error :(", Environment.NewLine), "Cant post", MessageBoxButtons.OK);
                }
                finally
                {
                    Close();
                }
            }
        }
    }
}
