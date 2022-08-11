using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplicationLogic
{
    class ArtistsLogic
    {
        private List<Artist> m_artistsList;
        private int m_currentArtistIndex = 0;
        private readonly string m_defaultArtistName;
        private readonly string m_defaultArtistImageURL;

        public ArtistsLogic(FacebookObjectCollection<Page> i_likedPages)
        {
            m_defaultArtistName = "Lady Gaga";
            m_defaultArtistImageURL = "https://scontent.ftlv1-1.fna.fbcdn.net/v/t39.30808-6/293874995_609082960586850_7360977058985292556_n.jpg?_nc_cat=1&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=wOcLbUiq8hYAX-PWvmo&_nc_oc=AQkHY6mcKcKpgpt-EDgErJ3Kz0dDbPaJwRmByJ-KtiaC_J20gbLi0Svv6Rp7PjGo-t1qV48uXxNo7DGRzqWmWmCx&_nc_ht=scontent.ftlv1-1.fna&oh=00_AT_m-CEmPwqz0SgwXDqVV1ZcByojFv4FidMzjyUHDDCugw&oe=62F8E5B2";
            m_artistsList = new List<Artist>();
            foreach (Page page in i_likedPages)
            {
                if (page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    m_artistsList.Add(new Artist(page.Name, page.PictureNormalURL));
                }
            }
        }

        public Artist GetDefaultArtist()
        {
            return new Artist(m_defaultArtistName, m_defaultArtistImageURL);
        }

        public Artist GetArtist()
        {
            Artist artist = null;
            if (m_artistsList.Count > 0)
            {
                artist = m_artistsList[m_currentArtistIndex];
            }
            return artist;
        }
    }
}
