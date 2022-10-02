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
    public class PostsSorter
    {
        public IComparer Comparer { get; set; }

        public PostsSorter(IComparer i_Comparer)
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
                            //doSwap(i_Posts[j], i_Posts[j + g]);
                            Post temp = i_Posts[j];
                            i_Posts[j] = i_Posts[j + g];
                            i_Posts[j + g] = temp;
                        }
                    }
                }
            }
        }

        private void doSwap(Post io_Num1, Post io_Num2)
        {
            Post temp = io_Num1;
            io_Num1 = io_Num2;
            io_Num2 = temp;
        }
    }
}
