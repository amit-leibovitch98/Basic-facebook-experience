using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    public class FacebookLogicService
    {
        private QuotesLoader m_quotesLoader;
        private ArtistsLogic m_artistsLogic;
        private string m_filePath;
        private LoginResult m_loginResult;
        private int m_groupsIndex = 0;
        private int m_teamsIndex = 0;
        private int m_pageIndex = 0;
        private int m_postsIndex = 0;
        private int m_artistIndex = 0;
        private int m_albumPhotoIndex = 0;
        private Album m_currentAlbum;
        private string m_quote;
        public AppSettings AppSettings { get; set; }

        public FacebookLogicService()
        {
            m_quotesLoader = new QuotesLoader();
            initXmlPath();
        }
        private void initXmlPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"AppSettings.xml");
            m_filePath = Path.GetFullPath(file);
        }

        public void LoadAppSettings()
        {
            if (File.Exists(m_filePath) && File.ReadAllText(m_filePath) != "")
            {
                AppSettings = AppSettings.LoadFromXmlFile(m_filePath);
            }
            else
            {
                AppSettings = new AppSettings();
            }
        }

        public void SaveSettings(Size i_size, Point i_location)
        {
            AppSettings.WindowSize = i_size;
            AppSettings.WindowLocation = i_location;

            if (AppSettings.RememberMe)
            {
                AppSettings.AccessToken = m_loginResult.AccessToken;
            }
            else
            {
                AppSettings.AccessToken = string.Empty;
            }

            AppSettings.SaveToXmlFile(m_filePath);
        }
       
        public bool Login(out string o_LoginFailedErrorMessage)
        {
            m_loginResult = FacebookService.Login(
                "329595859268386",
                /// requested permissions:
                "email",
                "user_friends",
                "public_profile",
                "groups_access_member_info",
                "user_posts",
                "user_photos",
                "user_likes"
                );
            o_LoginFailedErrorMessage = m_loginResult.ErrorMessage;
            return !string.IsNullOrEmpty(m_loginResult.AccessToken);
        }

        public bool Connect()
        {
            bool success = false;
            if (AppSettings.RememberMe && !string.IsNullOrEmpty(AppSettings.AccessToken))
            {
                m_loginResult = FacebookService.Connect(AppSettings.AccessToken);
                success = true;
            }
            return success;
        }

        public void Logout()
        {
            m_loginResult = null;
            m_artistsLogic = null;
            AppSettings.RememberMe = false;
            AppSettings.AccessToken = string.Empty;
            AppSettings.SaveToXmlFile(m_filePath);
        }

        public string GetProfilePictureUrl()
        {
            return m_loginResult.LoggedInUser.PictureNormalURL;
        }

        public string GetName()
        {
            return m_loginResult.LoggedInUser.Name;
        }

        public Group GetGroup()
        {
            return m_loginResult.LoggedInUser.Groups[m_groupsIndex];
        }

        public Group GetNextGroup()
        {
            m_groupsIndex = getNextIndex(m_groupsIndex, m_loginResult.LoggedInUser.Groups.Count);
            return GetGroup();
        }

        public Group GetPreviousGroup()
        {
            m_groupsIndex = getPrevIndex(m_groupsIndex, m_loginResult.LoggedInUser.Groups.Count);
            return GetGroup();
        }

        public Post GetPost()
        {
            return m_loginResult.LoggedInUser.Posts[m_postsIndex];
        }

        public Post GetNextPost()
        {
            m_postsIndex = getNextIndex(m_postsIndex, m_loginResult.LoggedInUser.Posts.Count);
            return GetPost();
        }

        public Post GetPreviousPost()
        {
            m_postsIndex = getPrevIndex(m_postsIndex, m_loginResult.LoggedInUser.Posts.Count);
            return GetPost();
        }

        public Page GetPage()
        {
            return m_loginResult.LoggedInUser.LikedPages[m_pageIndex];
        }

        public Page GetNextPage()
        {
            m_pageIndex = getNextIndex(m_pageIndex, m_loginResult.LoggedInUser.LikedPages.Count);
            return GetPage();
        }

        public Page GetPreviousPage()
        {
            m_pageIndex = getPrevIndex(m_pageIndex, m_loginResult.LoggedInUser.LikedPages.Count);
            return GetPage();
        }

        public List<string> GetAlbumNames()
        {
            List<string> albumNames = new List<string>();

            foreach (Album album in m_loginResult.LoggedInUser.Albums)
            {
                albumNames.Add(album.Name);
            }
            return albumNames;
        }

        public Album GetAlbumByName(string i_albumName)
        {
            Album returnedAlbum = null;
            foreach (Album album in m_loginResult.LoggedInUser.Albums)
            {
                if (album.Name == i_albumName)
                {
                    returnedAlbum = album;
                }
            }
            m_currentAlbum = returnedAlbum;
            return returnedAlbum;
        }

        public Page GetFavoriteTeam()
        {
            Page page = null;
            if (m_loginResult.LoggedInUser.FavofriteTeams != null)
            {
                page = m_loginResult.LoggedInUser.FavofriteTeams[m_teamsIndex];
            }
            return page;
        }

        public Page GetNextFavoriteTeam()
        {
            Page page = null;

            if (m_loginResult.LoggedInUser.FavofriteTeams != null)
            {
                m_teamsIndex = getNextIndex(m_teamsIndex, m_loginResult.LoggedInUser.FavofriteTeams.Length);
                page = m_loginResult.LoggedInUser.FavofriteTeams[m_teamsIndex];
            }
            page = GetFavoriteTeam();
            return page;
        }

        public Page GetPreviousFavoriteTeam()
        {
            Page page = null;

            if (m_loginResult.LoggedInUser.FavofriteTeams != null)
            {
                if (m_teamsIndex < 0)
                {
                    m_teamsIndex = getPrevIndex(m_teamsIndex, m_loginResult.LoggedInUser.FavofriteTeams.Length);
                    page = m_loginResult.LoggedInUser.FavofriteTeams[m_teamsIndex];
                }
            }
            page = GetFavoriteTeam();
            return page;
        }

        public List<string> GetEventNames()
        {
            List<string> eventNames = new List<string>();
            foreach (Event userEvent in m_loginResult.LoggedInUser.Events)
            {
                eventNames.Add(userEvent.Name);
            }
            return eventNames;
        }

        public Event GetEventByName(string i_eventName)
        {
            Event returnedEvent = null;
            foreach (Event userEvent in m_loginResult.LoggedInUser.Events)
            {
                if (userEvent.Name == i_eventName)
                {
                    returnedEvent = userEvent;
                }
            }
            return returnedEvent;
        }

        public string GetRandomQuote()
        {
            string quote = m_quotesLoader.getRandomQuote();
            m_quote = quote;
            return quote;
        }

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
            else
            {
                o_text = "";
            }

            if (i_post.Type == Post.eType.photo)
            {
                o_imgURL = i_post.PictureURL;
            }
        }

        public Artist GetArtist(out bool o_success)
        {
            Artist artist = null;
            if (m_artistsLogic == null)
            {
                m_artistsLogic = new ArtistsLogic(m_loginResult.LoggedInUser.LikedPages);
            }
            artist = m_artistsLogic.GetArtist();
            if (artist == null)
            {
                o_success = false;
                artist = m_artistsLogic.GetDefaultArtist();
            }
            else
            {
                o_success = true;
            }
            return artist;
        }

        public Artist GetNextArtist()
        {
            return m_artistsLogic.GetNextArtist();
        }

        public Artist GetPreviousArtist()
        {
            return m_artistsLogic.GetPreviousArtist();
        }

        public string GetFriendsNumber()
        {
            string numberOfFriends;
            try
            {
                numberOfFriends = m_loginResult.LoggedInUser.FriendLists.Count.ToString();
            }
            catch(Facebook.FacebookOAuthException)
            {
                numberOfFriends = "";
            }

            return numberOfFriends;
        }

        public int getPostLikes(Post i_post)
        {
            return m_loginResult.LoggedInUser.Posts[m_postsIndex].LikedBy.Count;
        }

        private int getNextIndex(int i_currentIndex, int i_listCount)
        {
            i_currentIndex++;
            if (i_currentIndex >= i_listCount)
            {
                i_currentIndex = 0;
            }
            return i_currentIndex;
        }

        private int getPrevIndex(int i_currentIndex, int i_listCount)
        {
            i_currentIndex--;
            if (i_currentIndex < 0)
            {
                i_currentIndex = i_listCount;
            }
            return i_currentIndex;
        }

        public void PostStatus(string i_Status)
        {
            m_loginResult.LoggedInUser.PostStatus(i_Status);
        }

        public string GetQuote()
        {
            return m_quote;
        }

        public Photo GetAlbumNextPhoto()
        {
            m_albumPhotoIndex = getNextIndex(m_albumPhotoIndex, m_currentAlbum.Photos.Count);
            return m_currentAlbum.Photos[m_albumPhotoIndex];
        }

        public Photo GetAlbumPreviousPhoto()
        {
            m_albumPhotoIndex = getPrevIndex(m_albumPhotoIndex, m_currentAlbum.Photos.Count);
            return m_currentAlbum.Photos[m_albumPhotoIndex];
        }
    }
}
