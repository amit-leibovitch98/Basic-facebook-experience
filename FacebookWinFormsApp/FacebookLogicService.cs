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
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public class FacebookLogicService
    {
        private QuotesLoader m_quotesLoader;
        private List<Page> m_artistsList;
        private string m_filePath;
        public User LoggedInUser { get; set; } = null;
        public LoginResult LoginResult { get; set; }
        public int GroupsIndex { get; set; } = 0;
        public int LikedArtistsIndex { get; set; } = 0;
        public AppSettings AppSettings { get; set; }
        public int TeamsIndex { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
        public int PostsIndex { get; set; } = 0;
        public int AlbumIndex { get; set; } = 0;
        public int ArtistIndex { get; set; } = 0;
        public string Quote { get; set;  }

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

        public void SaveSettings(Size size, Point location)
        {
            AppSettings.WindowSize = size;
            AppSettings.WindowLocation = location;

            if (AppSettings.RememberMe)
            {
                AppSettings.AccessToken = LoginResult.AccessToken;
            }
            else
            {
                AppSettings.AccessToken = string.Empty;
            }

            AppSettings.SaveToXmlFile(m_filePath);
        }
       
        public bool Login(out string o_LoginFailedErrorMessage)
        {
            LoginResult = FacebookService.Login(
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
            o_LoginFailedErrorMessage = LoginResult.ErrorMessage;
            return !string.IsNullOrEmpty(LoginResult.AccessToken);
        }

        public bool Connect()
        {
            bool success = false;
            if (AppSettings.RememberMe && !string.IsNullOrEmpty(AppSettings.AccessToken))
            {
                LoginResult = FacebookService.Connect(AppSettings.AccessToken);
                LoggedInUser = LoginResult.LoggedInUser;
                success = true;
            }
            return success;
        }

        public void Logout()
        {
            LoggedInUser = null;
            LoginResult = null;
            m_artistsList = null;
            AppSettings.RememberMe = false;
            AppSettings.AccessToken = string.Empty;
            AppSettings.SaveToXmlFile(m_filePath);
        }

        public string GetProfilePictureUrl()
        {
            return LoginResult.LoggedInUser.PictureNormalURL;
        }

        public string GetName()
        {
            return LoginResult.LoggedInUser.Name;
        }

        public Group GetGroup()
        {
            return LoginResult.LoggedInUser.Groups[GroupsIndex];
        }

        public Group GetNextGroup()
        {
            GroupsIndex = getNextIndex(GroupsIndex, LoggedInUser.Groups.Count);
            return GetGroup();
        }

        public Group GetPreviousGroup()
        {
            GroupsIndex = getPrevIndex(GroupsIndex, LoggedInUser.Groups.Count);
            return GetGroup();
        }

        public Post GetPost()
        {
            return LoginResult.LoggedInUser.Posts[PostsIndex];
        }

        public Post GetNextPost()
        {
            PostsIndex = getNextIndex(PostsIndex, LoggedInUser.Posts.Count);
            return GetPost();
        }

        public Post GetPreviousPost()
        {
            PostsIndex = getPrevIndex(PostsIndex, LoggedInUser.Posts.Count);
            return GetPost();
        }

        public Page GetPage()
        {
            return LoginResult.LoggedInUser.LikedPages[PageIndex];
        }

        public Page GetNextPage()
        {
            PageIndex = getNextIndex(PageIndex, LoggedInUser.LikedPages.Count);
            return GetPage();
        }

        public Page GetPreviousPage()
        {
            PageIndex = getPrevIndex(PageIndex, LoggedInUser.LikedPages.Count);
            return GetPage();
        }

        public List<string> GetAlbumNames()
        {
            List<string> albumNames = new List<string>();

            foreach (Album album in LoginResult.LoggedInUser.Albums)
            {
                albumNames.Add(album.Name);
            }
            return albumNames;
        }

        public Album GetAlbumByName(string albumName)
        {
            Album returnedAlbum = null;
            foreach (Album album in LoginResult.LoggedInUser.Albums)
            {
                if (album.Name == albumName)
                {
                    returnedAlbum = album;
                }
            }
            return returnedAlbum;
        }

        public Page GetFavoriteTeam()
        {
            Page page = null;
            if (LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                page = LoginResult.LoggedInUser.FavofriteTeams[TeamsIndex];
            }
            return page;
        }

        public Page GetNextFavoriteTeam()
        {
            Page page = null;

            if (LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                TeamsIndex = getNextIndex(TeamsIndex, LoggedInUser.FavofriteTeams.Length);
                page = LoggedInUser.FavofriteTeams[TeamsIndex];
            }
            page = GetFavoriteTeam();
            return page;
        }

        public Page GetPreviousFavoriteTeam()
        {
            Page page = null;

            if (LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                if (TeamsIndex < 0)
                {
                    TeamsIndex = getPrevIndex(TeamsIndex, LoggedInUser.FavofriteTeams.Length);
                    page = LoggedInUser.FavofriteTeams[TeamsIndex];
                }
            }
            page = GetFavoriteTeam();
            return page;
        }

        public List<string> GetEventNames()
        {
            List<string> eventNames = new List<string>();
            foreach (Event userEvent in LoginResult.LoggedInUser.Events)
            {
                eventNames.Add(userEvent.Name);
            }
            return eventNames;
        }

        public Event GetEventByName(string eventName)
        {
            Event returnedEvent = null;
            foreach (Event userEvent in LoginResult.LoggedInUser.Events)
            {
                if (userEvent.Name == eventName)
                {
                    returnedEvent = userEvent;
                }
            }
            return returnedEvent;
        }

        public string GetRandomQuote()
        {
            string quote = m_quotesLoader.getRandomQuote();
            Quote = quote;
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
                o_text = "-no text to show-";
            }

            if (i_post.Type == Post.eType.photo)
            {
                o_imgURL = i_post.PictureURL;
            }
        }

        public List<Page> GetArtistsList(List<Page> i_likedPages)
        {
            List<Page> artistsList = new List<Page>();
            foreach (Page page in i_likedPages)
            {
                if (page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    artistsList.Add(page);
                }
            }

            return artistsList;
        }

        private List<Page> getArtistsList()
        {
            List<Page> artistsList = new List<Page>();
            foreach (Page page in LoginResult.LoggedInUser.LikedPages)
            {
                if (page.Category == "Musician/band" || page.Category == "מוזיקאי/להקה" || page.Category == "Artist")
                {
                    artistsList.Add(page);
                }
            }

            return artistsList;
        }

        public Page GetArtistPage()
        {
            Page artistPage = null;
            if (m_artistsList == null)
            {
                m_artistsList = getArtistsList();
            }
            if (m_artistsList.Count > 0)
            {
                artistPage = m_artistsList[ArtistIndex];
            }
            return artistPage;
        }

        public Page GetNextArtistPage()
        {
            Page artistPage = null;
            if (m_artistsList == null)
            {
                m_artistsList = getArtistsList();
            }
            if (m_artistsList.Count > 0)
            {
                ArtistIndex = getNextIndex(ArtistIndex, m_artistsList.Count);
                artistPage = m_artistsList[ArtistIndex];
            }
            return artistPage;
        }

        public Page GetPreviousArtistPage()
        {
            Page artistPage = null;
            if (m_artistsList == null)
            {
                m_artistsList = getArtistsList();
            }
            if (m_artistsList.Count > 0)
            {
                ArtistIndex = getPrevIndex(ArtistIndex, m_artistsList.Count);
                artistPage = m_artistsList[ArtistIndex];
            }

            return artistPage;
        }

        public string GetFriendsNumber()
        {
            string numberOfFriends;
            try
            {
                numberOfFriends = LoggedInUser.FriendLists.Count.ToString();
            }
            catch(Facebook.FacebookOAuthException)
            {
                numberOfFriends = "";
            }

            return numberOfFriends;
        }
        /*
        public string GetNextPicInAlbum(int i_AlbumIndex)
        {
            string pictureUrl = LoggedInUser.Albums[i_AlbumIndex].Photos[AlbumIndex].PictureNormalURL;
            AlbumIndex++;

            return pictureUrl;
        }
        */

        public int getPostLikes(Post i_post)
        {
            return LoggedInUser.Posts[PostsIndex].LikedBy.Count;
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
    }
}
