using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    public class InfoLogic
    {
        public void GetPostTextAndPicture(Post i_post, out string o_text, out string o_imgURL)
        {
            o_text = string.Empty;
            o_imgURL = string.Empty;
            if (i_post.Message != null)
            {
                o_text = i_post.Message;
            }
            else if (i_post.Caption != null)
            {
                o_text = i_post.Caption;
            }

            if (i_post.Type == Post.eType.photo)
            {
                o_imgURL = i_post.PictureURL;
            }
        }
    }
}
