using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    public class PostsSorter
    {
        public IPostsComparer Comparer { get; set; }

        public PostsSorter(IPostsComparer i_Comparer)
        {
            Comparer = i_Comparer;
        }

        public void Sort(FacebookObjectCollection<Post> i_Posts)
        {
            for (int g = i_Posts.Count / 2; g > 0; g /= 2)
            {
                for (int i = g; i < i_Posts.Count; i++)
                {
                    for (int j = i - g; j >= 0; j -= g)
                    {
                        if (Comparer.ShouldSwap(i_Posts[j], i_Posts[j + g]))
                        {
                            swap(i_Posts, j, j + g);
                        }
                    }
                }
            }
        }

        private void swap(FacebookObjectCollection<Post> i_Posts, int i_FirstIndex, int i_SecondIndex)
        {
            Post temp = i_Posts[i_FirstIndex];
            i_Posts[i_FirstIndex] = i_Posts[i_SecondIndex];
            i_Posts[i_SecondIndex] = temp;
        }
    }
}
