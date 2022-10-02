using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    // shachar
    public interface IComparer
    {
        bool ShouldSwap(Post i_Post1, Post i_Post2);
    }

    public class DownByLikesComparer : IComparer
    {
        public bool ShouldSwap(Post i_Post1, Post i_Post2)
        {
            return i_Post1.Comments.Count < i_Post2.Comments.Count;
        }
    }
}
