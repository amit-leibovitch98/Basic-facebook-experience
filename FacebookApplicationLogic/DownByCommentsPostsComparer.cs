using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookApplicationLogic
{
    public class DownByCommentsPostsComparer : IPostsComparer
    {
        public bool ShouldSwap(Post i_Post1, Post i_Post2)
        {
            return i_Post1.Comments.Count < i_Post2.Comments.Count;
        }
    }
}
