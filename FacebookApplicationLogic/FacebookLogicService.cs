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
    public sealed class FacebookLogicService
    {
        private static FacebookLogicService s_Instance = null;
        private static object s_LockObj = new Object();
        private string m_AppSettingsXmlFilePath;
        private IQuotesLoader m_QuotesLoader;
        private ArtistsLogic m_ArtistsLogic;
        private LoginResult m_LoginResult;
        private int m_GroupsIndex = 0;
        private int m_TeamsIndex = 0;
        private int m_PageIndex = 0;
        private int m_PostsIndex = 0;
        private int m_AlbumPhotoIndex = 0;
        private Album m_CurrentAlbum;
        private string m_Quote;

        public AppSettings AppSettings { get; set; }

        private FacebookLogicService()
        {
            m_QuotesLoader = new QuotesLoaderCachingProxy();
            initXmlPath();
        }

        public static FacebookLogicService Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new FacebookLogicService();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public LoginResult CurrentLoginResult
        {
            get
            {
                return m_LoginResult;
            }
        }

        private void initXmlPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"AppSettings.xml");

            m_AppSettingsXmlFilePath = Path.GetFullPath(file);
        }

        public void LoadAppSettings()
        {
            AppSettings = new AppSettings();
            if (File.Exists(m_AppSettingsXmlFilePath) && File.ReadAllText(m_AppSettingsXmlFilePath) != string.Empty)
            {
                AppSettings.LoadFromXmlFile(m_AppSettingsXmlFilePath);
            }
        }

        public void SaveSettings(Size i_Size, Point i_Location)
        {
            AppSettings.WindowSize = i_Size;
            AppSettings.WindowLocation = i_Location;

            if (AppSettings.RememberMe)
            {
                AppSettings.AccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                AppSettings.AccessToken = string.Empty;
            }

            AppSettings.SaveToXmlFile(m_AppSettingsXmlFilePath);
        }

        public bool Login(out string o_LoginFailedErrorMessage)
        {
            m_LoginResult = FacebookService.Login(/// requested permissions:
                "329595859268386",
                "email",
                "user_friends",
                "public_profile",
                "groups_access_member_info",
                "user_posts",
                "user_photos",
                "user_likes");
            o_LoginFailedErrorMessage = m_LoginResult.ErrorMessage;

            return !string.IsNullOrEmpty(m_LoginResult.AccessToken);
        }

        public bool Connect()
        {
            bool success = false;

            if (AppSettings.RememberMe && !string.IsNullOrEmpty(AppSettings.AccessToken))
            {
                m_LoginResult = FacebookService.Connect(AppSettings.AccessToken);
                success = true;
            }

            return success;
        }

        public void Logout()
        {
            m_LoginResult = null;
            m_ArtistsLogic = null;
            AppSettings.RememberMe = false;
            AppSettings.AccessToken = string.Empty;
            AppSettings.SaveToXmlFile(m_AppSettingsXmlFilePath);
        }

        public string GetProfilePictureUrl()
        {
            return m_LoginResult.LoggedInUser.PictureNormalURL;
        }

        public string GetName()
        {
            return m_LoginResult.LoggedInUser.Name;
        }

        public Group GetGroup()
        {
            return m_LoginResult.LoggedInUser.Groups[m_GroupsIndex];
        }

        public Group GetNextGroup()
        {
            m_GroupsIndex = getNextIndex(m_GroupsIndex, m_LoginResult.LoggedInUser.Groups.Count);

            return GetGroup();
        }

        public Group GetPreviousGroup()
        {
            m_GroupsIndex = getPrevIndex(m_GroupsIndex, m_LoginResult.LoggedInUser.Groups.Count);

            return GetGroup();
        }

        public Post GetPost()
        {
            return m_LoginResult.LoggedInUser.Posts[m_PostsIndex];
        }

        public Post GetNextPost()
        {
            m_PostsIndex = getNextIndex(m_PostsIndex, m_LoginResult.LoggedInUser.Posts.Count);

            return GetPost();
        }

        public Post GetPreviousPost()
        {
            m_PostsIndex = getPrevIndex(m_PostsIndex, m_LoginResult.LoggedInUser.Posts.Count);

            return GetPost();
        }

        public Page GetPage()
        {
            return m_LoginResult.LoggedInUser.LikedPages[m_PageIndex];
        }

        public Page GetNextPage()
        {
            m_PageIndex = getNextIndex(m_PageIndex, m_LoginResult.LoggedInUser.LikedPages.Count);

            return GetPage();
        }

        public Page GetPreviousPage()
        {
            m_PageIndex = getPrevIndex(m_PageIndex, m_LoginResult.LoggedInUser.LikedPages.Count);

            return GetPage();
        }

        public List<string> GetAlbumNames()
        {
            List<string> albumNames = new List<string>();

            foreach (Album album in m_LoginResult.LoggedInUser.Albums)
            {
                albumNames.Add(album.Name);
            }

            return albumNames;
        }

        public Album GetAlbumByName(string i_AlbumName)
        {
            Album returnedAlbum = null;
            foreach (Album album in m_LoginResult.LoggedInUser.Albums)
            {
                if (album.Name == i_AlbumName)
                {
                    returnedAlbum = album;
                }
            }

            m_CurrentAlbum = returnedAlbum;

            return returnedAlbum;
        }

        public Page GetFavoriteTeam()
        {
            Page page = null;

            if (m_LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                page = m_LoginResult.LoggedInUser.FavofriteTeams[m_TeamsIndex];
            }

            return page;
        }

        public Page GetNextFavoriteTeam()
        {
            Page page = null;

            if (m_LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                m_TeamsIndex = getNextIndex(m_TeamsIndex, m_LoginResult.LoggedInUser.FavofriteTeams.Length);
                page = m_LoginResult.LoggedInUser.FavofriteTeams[m_TeamsIndex];
            }

            page = GetFavoriteTeam();

            return page;
        }

        public Page GetPreviousFavoriteTeam()
        {
            Page page = null;

            if (m_LoginResult.LoggedInUser.FavofriteTeams != null)
            {
                if (m_TeamsIndex < 0)
                {
                    m_TeamsIndex = getPrevIndex(m_TeamsIndex, m_LoginResult.LoggedInUser.FavofriteTeams.Length);
                    page = m_LoginResult.LoggedInUser.FavofriteTeams[m_TeamsIndex];
                }
            }

            page = GetFavoriteTeam();

            return page;
        }

        public List<string> GetEventNames()
        {
            List<string> eventNames = new List<string>();
            foreach (Event userEvent in m_LoginResult.LoggedInUser.Events)
            {
                eventNames.Add(userEvent.Name);
            }

            return eventNames;
        }

        public Event GetEventByName(string i_EventName)
        {
            Event returnedEvent = null;
            foreach (Event userEvent in m_LoginResult.LoggedInUser.Events)
            {
                if (userEvent.Name == i_EventName)
                {
                    returnedEvent = userEvent;
                }
            }

            return returnedEvent;
        }

        public string GetRandomQuote()
        {
            m_QuotesLoader.GetRandomQuote(out m_Quote);

            return m_Quote;
        }

        public void GetPostTextAndPicture(Post i_Post, out string o_Text, out string o_ImgURL)
        {
            o_Text = string.Empty;
            o_ImgURL = string.Empty;
            if (i_Post.Message != null)
            {
                o_Text = i_Post.Message;
            }
            else if (i_Post.Caption != null)
            {
                o_Text = i_Post.Caption;
            }
            else
            {
                o_Text = string.Empty;
            }

            if (i_Post.Type == Post.eType.photo)
            {
                o_ImgURL = i_Post.PictureURL;
            }
        }

        public Artist GetArtist(out bool o_Success)
        {
            Artist artist = null;
            if (m_ArtistsLogic == null)
            {
                m_ArtistsLogic = new ArtistsLogic(m_LoginResult.LoggedInUser.LikedPages);
            }

            artist = m_ArtistsLogic.GetArtist();
            if (artist == null)
            {
                o_Success = false;
                artist = m_ArtistsLogic.GetDefaultArtist();
            }
            else
            {
                o_Success = true;
            }

            return artist;
        }

        public Artist GetNextArtist()
        {
            return m_ArtistsLogic.GetNextArtist();
        }

        public Artist GetPreviousArtist()
        {
            return m_ArtistsLogic.GetPreviousArtist();
        }

        public string GetFriendsNumber()
        {
            string numberOfFriends;
            try
            {
                numberOfFriends = m_LoginResult.LoggedInUser.FriendLists.Count.ToString();
            }
            catch(Facebook.FacebookOAuthException)
            {
                numberOfFriends = string.Empty;
            }

            return numberOfFriends;
        }

        public string getPostLikes(Post i_Post)
        {
            string likesCount;
            try
            {
                likesCount = i_Post.LikedBy.Count.ToString();
            }
            catch(Facebook.FacebookOAuthException)
            {
                likesCount = string.Empty;
            }

            return likesCount;
        }

        private int getNextIndex(int i_CurrentIndex, int i_ListCount)
        {
            i_CurrentIndex++;
            if (i_CurrentIndex >= i_ListCount)
            {
                i_CurrentIndex = 0;
            }

            return i_CurrentIndex;
        }

        private int getPrevIndex(int i_CurrentIndex, int i_ListCount)
        {
            i_CurrentIndex--;
            if (i_CurrentIndex < 0)
            {
                i_CurrentIndex = i_ListCount;
            }

            return i_CurrentIndex;
        }

        public void PostStatus(string i_Status)
        {
            m_LoginResult.LoggedInUser.PostStatus(i_Status);
        }

        public string GetQuote()
        {
            return m_Quote;
        }

        public Photo GetAlbumNextPhoto()
        {
            m_AlbumPhotoIndex = getNextIndex(m_AlbumPhotoIndex, m_CurrentAlbum.Photos.Count);

            return m_CurrentAlbum.Photos[m_AlbumPhotoIndex];
        }

        public Photo GetAlbumPreviousPhoto()
        {
            m_AlbumPhotoIndex = getPrevIndex(m_AlbumPhotoIndex, m_CurrentAlbum.Photos.Count);

            return m_CurrentAlbum.Photos[m_AlbumPhotoIndex];
        }

        //shachar
        public void SortPostsByCommentsNumber()
        {
            PostsSorter postsSorter = new PostsSorter(new DownByLikesComparer());

            postsSorter.Sort(m_LoginResult.LoggedInUser.Posts);
            m_PostsIndex = 0;
        }

        public void ChangeQuote(string i_NewQuote)
        {
            m_Quote = i_NewQuote + string.Format("{0}(This Quote may has been edited.)", Environment.NewLine);
        }
    }
}
