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
            bool isLikedByexist = false;

            if (isLikedByexist)
            {
                foreach (User likedUser in i_Post.LikedBy)
                {
                    listBoxLikes.Items.Add(string.Format("{0} {1}", likedUser.FirstName, likedUser.LastName));
                }
            }
        }
    }
}
