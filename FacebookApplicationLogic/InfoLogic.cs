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

        public List<Page> GetArtistsList(List<Page> i_likedPages)
        {
            List<Page> artistsList = new List<Page>();
            foreach(Page page in i_likedPages)
            {
                if(page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    artistsList.Add(page);
                }
            }

            return artistsList;
        }

        /*
        public List<ArtistPage> GetArtistsList()
        {
            List<ArtistPage> likedArtists = null;
            List<string> likedArtistsStr = null;

            string json;

            using (WebClient wc = new WebClient())
            {
                var vjson = wc.DownloadString("https://graph.facebook.com/v14.0/me?fields=likes.limit(10)%7Bcategory%2Cname%2Cpicture%7D&access_token=EAAErxAQccyIBAE8gHTTtto5t0aP2ZAWXxvuuDqpCIkdtVDwVOatvez4NZB5QxVZBc6RoOZAQPVsqKG3PK20kfbssQMmbROdr9ZC22vhPZCO8AC5fowIcy8S724sYXgH5tp25ZAHcelpEge9xgGpHZA73pdpXAtEhJxl9KtBLR5REkcjV3lOEt7nODZBZBJNzOI0lky7XDxF8yiaQZDZD");
            }
            //likedArtistsStr = JsonConvert.DeserializeObject<List<string>>(vjson);
            foreach (ArtistPage page in likedArtists)
            {
                if (page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    likedArtists.Add(page);
                }
            }
            return likedArtists;
        */
    }
}
