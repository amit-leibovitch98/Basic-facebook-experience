using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormLikes : Form
    {
        public FormLikes(Post i_Post)
        {
            InitializeComponent();

            try
            {
                foreach (User likedUser in i_Post.LikedBy)
                {
                    listBoxLikes.Invoke(new Action(() => listBoxLikes.Items.Add(string.Format("{0} {1}", likedUser.FirstName, likedUser.LastName))));
                }
            }
            catch (Facebook.FacebookOAuthException)
            {
                labelLikesError.Visible = true;
            }
        }
    }
}
