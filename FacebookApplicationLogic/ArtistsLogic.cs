using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookApplicationLogic
{
    public class ArtistsLogic
    {
        private readonly string m_DefaultArtistName;
        private readonly string m_DefaultArtistImageURL;
        private List<Artist> m_ArtistsList;
        private int m_CurrentArtistIndex = 0;

        public ArtistsLogic(FacebookObjectCollection<Page> i_likedPages)
        {
            m_DefaultArtistName = "Lady Gaga";
            m_DefaultArtistImageURL = "https://imageio.forbes.com/specials-images/imageserve/5ed6716cdd5d320006caf933/0x0.jpg?format=jpg&crop=1080,1080,x0,y0,safe&height=416&width=416&fit=bounds"; //"https://upload.wikimedia.org/wikipedia/commons/0/0e/Lady_Gaga_at_Joe_Biden%27s_inauguration_%28cropped_5%29.jpg"; //"https://scontent.ftlv1-1.fna.fbcdn.net/v/t39.30808-6/293874995_609082960586850_7360977058985292556_n.jpg?_nc_cat=1&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=wOcLbUiq8hYAX-PWvmo&_nc_oc=AQkHY6mcKcKpgpt-EDgErJ3Kz0dDbPaJwRmByJ-KtiaC_J20gbLi0Svv6Rp7PjGo-t1qV48uXxNo7DGRzqWmWmCx&_nc_ht=scontent.ftlv1-1.fna&oh=00_AT_m-CEmPwqz0SgwXDqVV1ZcByojFv4FidMzjyUHDDCugw&oe=62F8E5B2";
            m_ArtistsList = new List<Artist>();
            foreach (Page page in i_likedPages)
            {
                if (page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    m_ArtistsList.Add(new Artist(page.Name, page.PictureNormalURL));
                }
            }
        }

        public Artist GetDefaultArtist()
        {
            return new Artist(m_DefaultArtistName, m_DefaultArtistImageURL);
        }

        public Artist GetArtist()
        {
            Artist artist = null;
            if (m_ArtistsList.Count > 0)
            {
                artist = m_ArtistsList[m_CurrentArtistIndex];
            }

            return artist;
        }

        public Artist GetNextArtist()
        {
            m_CurrentArtistIndex++;
            if (m_CurrentArtistIndex >= m_ArtistsList.Count)
            {
                m_CurrentArtistIndex = 0;
            }

            return GetArtist();
        }

        public Artist GetPreviousArtist()
        {
            m_CurrentArtistIndex--;
            if (m_CurrentArtistIndex <= 0)
            {
                m_CurrentArtistIndex = m_ArtistsList.Count - 1;
            }

            return GetArtist();
        }
    }
}
