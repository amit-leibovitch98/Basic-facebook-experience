using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookApplicationLogic
{
    public interface IPostsComparer
    {
        bool ShouldSwap(Post i_Post1, Post i_Post2);
    }
}
