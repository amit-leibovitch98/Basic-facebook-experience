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

        public ArtistsLogic(FacebookObjectCollection<Page> i_LikedPages)
        {
            m_DefaultArtistName = "Lady Gaga";
            m_DefaultArtistImageURL = "https://imageio.forbes.com/specials-images/imageserve/5ed6716cdd5d320006caf933/0x0.jpg?format=jpg&crop=1080,1080,x0,y0,safe&height=416&width=416&fit=bounds";
            m_ArtistsList = new List<Artist>();
            foreach (Page page in i_LikedPages)
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
