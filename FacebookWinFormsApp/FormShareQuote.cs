using System;
using System.Windows.Forms;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public partial class FormShareQuote : Form
    {
        private FacebookLogicService m_FacebookLogicService;
        private QuoteChangesNotifier m_QuoteChanges;

        public FormShareQuote()
        {
            InitializeComponent();
            m_FacebookLogicService = FacebookLogicService.Instance;
            textBoxToPost.Text = m_FacebookLogicService.GetQuote();
            m_QuoteChanges = new QuoteChangesNotifier();
            m_QuoteChanges.QuoteModified += m_FacebookLogicService.ModifiedQuote;
        }

        private void buttonShareQuote_Click(object sender, EventArgs e)
        {
            bool cancelPost = false;
            string quoteToPost = textBoxToPost.Text;

            if(m_FacebookLogicService.GetQuote() != quoteToPost)
            {
                m_QuoteChanges.NotifyAll(quoteToPost);
                quoteToPost = m_FacebookLogicService.GetPostedQuote();
                DialogResult dialogResult = MessageBox.Show(string.Format("Notice!{0}Since you have altered the quote, we added a disclaimer to your post.{1}It will now look like this: {2}{3}Do you still want to post it?", Environment.NewLine, Environment.NewLine, quoteToPost, Environment.NewLine), "Notice!", MessageBoxButtons.YesNo);

                if (dialogResult.Equals(DialogResult.No))
                {
                    Close();
                    cancelPost = true;
                }
            }

            if (!cancelPost)
            {
                try
                {
                    m_FacebookLogicService.PostStatus(quoteToPost);
                }
                catch (Facebook.FacebookOAuthException)
                {
                    MessageBox.Show(string.Format("Can't post{0}Due to server error :(", Environment.NewLine), "Cant post", MessageBoxButtons.OK);
                }
                finally
                {
                    Close();
                }
            }
        }
    }
}
