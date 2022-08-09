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
        private InfoLogic m_infoLogic;
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
        public string FilePath { get; }

        public FacebookLogicService()
        {
            m_quotesLoader = new QuotesLoader();
            m_infoLogic = new InfoLogic();
        }
        public void InitPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"AppSettings.xml");
            m_filePath = Path.GetFullPath(file);
        }

        public void SetAppSettings()
        {
            if (File.Exists(FilePath) && File.ReadAllText(FilePath) != "")
            {
                AppSettings = AppSettings.LoadFromXmlFile(FilePath);
            }
            else
            {
                AppSettings = new AppSettings();
            }
        }
       
        public bool LogIn()
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

            return !string.IsNullOrEmpty(LoginResult.AccessToken);
        }

        public Group GetGroup()
        {
            return LoginResult.LoggedInUser.Groups[GroupsIndex];
        }

        public Group GetNextGroup()
        {
            GroupsIndex++;
            if (GroupsIndex >= LoginResult.LoggedInUser.Groups.Count)
            {
                GroupsIndex = 0;
            }
            return GetGroup();
        }

        public Group GetPreviousGroup()
        {
            GroupsIndex--;
            if (GroupsIndex < 0)
            {
                GroupsIndex = LoginResult.LoggedInUser.Groups.Count - 1;
            }
            return GetGroup();
        }

        public Post GetPost()
        {
            return LoginResult.LoggedInUser.Posts[PostsIndex];
        }

        public Post GetNextPost()
        {
            PostsIndex++;
            if (PostsIndex >= LoginResult.LoggedInUser.Posts.Count)
            {
                PostsIndex = 0;
            }
            return GetPost();
        }

        public Post GetPreviousPost()
        {
            PostsIndex--;
            if (PostsIndex < 0)
            {
                PostsIndex = LoginResult.LoggedInUser.Posts.Count - 1;
            }
            return GetPost();
        }

        public Page GetPage()
        {
            return LoginResult.LoggedInUser.LikedPages[PageIndex];
        }

        public Page GetNextPage()
        {
            PageIndex++;
            if (PageIndex >= LoginResult.LoggedInUser.LikedPages.Count)
            {
                PageIndex = 0;
            }
            return GetPage();
        }

        public Page GetPreviousPage()
        {
            PageIndex--;
            if (PageIndex < 0)
            {
                PageIndex = LoggedInUser.LikedPages.Count - 1;
            }
            return GetPage();
        }

    }
}
