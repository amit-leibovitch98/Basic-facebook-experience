using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private string m_AccessToken;
        public User LoggedInUser { get; set; } = null;
        public LoginResult LoginResult { get; set; }
        public int GroupsIndex { get; set; } = 0;
        public int TeamsIndex { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
        public int PostsIndex { get; set; } = 37;

        public int AlbumIndex { get; set; } = 0;
        private QuotesLoader m_quotesLoader;
        private InfoLogic m_infoLogic;
        public AppSettings m_AppSettings;


        public FormMain()
        {
            InitializeComponent();
            
            Size = new Size(180, 280);
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            //
            m_AppSettings = AppSettings.LoadFromXmlFile();

            if (m_AppSettings.RememberMe)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = m_AppSettings.WindowSize;
                this.Location = m_AppSettings.WindowLocation;
                this.checkBoxRememberMe.Checked = m_AppSettings.RememberMe;
            
            }
            else
            {
                switchToLoginMode();
            }
            //
            m_quotesLoader = new QuotesLoader();
            m_infoLogic = new InfoLogic();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_AppSettings.RememberMe && !string.IsNullOrEmpty(m_AppSettings.AccessToken))
            {
                LoginResult = FacebookService.Connect(m_AppSettings.AccessToken);
                InitInfoAfterLogin();
                pictureBoxLogin.Visible = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            m_AppSettings.WindowSize = Size;
            m_AppSettings.WindowLocation = Location;
            //m_AppSettings.RememberMe = this.checkBoxRememberMe.Checked;

            if (m_AppSettings.RememberMe)
            {
                m_AppSettings.AccessToken = m_AccessToken;
            }
            else
            {
                m_AppSettings.AccessToken = string.Empty;
            }

            m_AppSettings.SaveToXmlFile();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc"); /// the current password for Desig Patter

            LoginResult = FacebookService.Login(
                    /// (This is Desig Patter's App ID. replace it with your own)
                    "329595859268386",
                    /// requested permissions:
                    "email",
                    "user_friends",
                    "public_profile",
                    "groups_access_member_info",
                    "user_posts",
                    "user_photos",
                    "user_likes"
                    /// add any relevant permissions
                    );
            pictureBoxLogin.Visible = false;
            InitInfoAfterLogin();
        }

        private void InitInfoAfterLogin()
        {
            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                LoggedInUser = LoginResult.LoggedInUser;
                m_AccessToken = LoginResult.AccessToken;
                fetchUserInfo();
                labelUserName.Text = string.Format("{0} {1}", LoggedInUser.Name, LoggedInUser.LastName);
                labelUserName.Visible = true;
                buttonLogin.Visible = false;
                if (checkBoxRememberMe.Checked == true)
                {
                    m_AppSettings.RememberMe = true;
                }
                Size = new Size(770, 570);
                tabControl.Visible = true;
                buttonLogout.Visible = true;
                checkBoxRememberMe.Visible = false;
                labelInsperetionalQuote.Visible = true;
                labelInsperetionalQuote.Text = m_quotesLoader.getRandomQuote();
            }
            else
            {
                MessageBox.Show(LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(LoggedInUser.PictureNormalURL);
            //labelPosts.Text = LoggedInUser.Posts[0].Message;
            fetchGroup();
            fetchPost();
            fetchPage();
            fetchFavoriteTeams();
            fetchEvents();
            AlbumsInit();
        }

        private void fetchPost()
        {
            string postText, imgURL;
            Post post = LoggedInUser.Posts[PostsIndex];
            m_infoLogic.GetPostTextAndPicture(post, out postText, out imgURL);
            labelPosts.Text = postText;
            labelPostComments.Text = string.Format("({0}) Comments", post.Comments.Count);
            if (imgURL != "")
            {
                pictureBoxPostImg.LoadAsync(imgURL);
            }
            else
            {
                pictureBoxPostImg.Image = null;
            }
            //labelLikes.Text = string.Format("({0}) Likes", originalPost.LikedBy.Count);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //FacebookService.LogoutWithUI();
            pictureBoxProfile.Image = null;
            buttonLogin.Text = "Login";
            LoginResult = null;
            switchToLoginMode();
            m_AppSettings.RememberMe = false;
            m_AppSettings.AccessToken = string.Empty;
            m_AppSettings.SaveToXmlFile();
        }

        private void switchToLoginMode()
        {
            this.Size = new Size(180, 280);
            this.pictureBoxLogin.Visible = false;
            this.pictureBoxLogin.Visible = true;
            this.buttonLogin.Visible = true;
            this.labelUserName.Visible = false;
            this.buttonLogout.Visible = false;
            this.labelInsperetionalQuote.Visible = false;
            this.checkBoxRememberMe.Visible = true;
            this.checkBoxRememberMe.Checked = false;
        }

        private void buttonNextPost_Click(object sender, EventArgs e)
        {
            PostsIndex++;
            if (PostsIndex >= LoggedInUser.Posts.Count)
            {
                PostsIndex = 0;
            }
            fetchPost();
        }

        private void buttonPrevPost_Click(object sender, EventArgs e)
        {
            PostsIndex--;
            if (PostsIndex < 0)
            {
                PostsIndex = LoggedInUser.Posts.Count - 1;
            }
            fetchPost();
        }

        private void labelLikes_Click(object sender, EventArgs e)
        {
            FormLikes formLikes = new FormLikes(LoggedInUser.Posts[PostsIndex]);
            formLikes.ShowDialog();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {

            LoginResult = FacebookService.Connect(m_AppSettings.AccessToken);
            InitInfoAfterLogin();
        }

        private void fetchPage()
        {
            Page page = LoggedInUser.LikedPages[PageIndex];
            pictureBoxPageLogo.LoadAsync(page.PictureSqaureURL);
            //pictureBoxPageCover.LoadAsync(page.Cover.SourceURL);
            labelPageName.Text = page.Name;
            labelPageCategory.Text = page.Category;
            labelPageLikes.Text = string.Format("({0}) Likes", page.LikesCount);
            /*
            
            DOESN"T WORK :(
              
            foreach (Photo picture in page.Pictures)
            {
                imageListPageUploadedPictures.Images.Add(picture.ImageNormal);
            }
            
            foreach (Album album in page.Albums)
            {

                foreach (Photo picture in album.Photos)
                {
                    imageListPageUploadedPictures.Images.Add(picture.ImageNormal);
                }
            }
            */
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            PageIndex++;
            if (PageIndex >= LoggedInUser.LikedPages.Count)
            {
                PageIndex = 0;
            }
            fetchPage();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            PageIndex--;
            if (PageIndex < 0)
            {
                PageIndex = LoggedInUser.LikedPages.Count - 1;
            }
            fetchPage();
        }

        private void fetchGroup()
        {
            LabelGroupName.Text = LoggedInUser.Groups[GroupsIndex].Name;
            pictureBoxGroup.Image = LoggedInUser.Groups[GroupsIndex].ImageNormal;
            labelGroupMembers.Text = string.Format("{0} members", LoggedInUser.Groups[GroupsIndex].Description);

        }

        private void buttonNextGroup_Click(object sender, EventArgs e)
        {

            GroupsIndex++;
            if (GroupsIndex >= LoggedInUser.Groups.Count)
            {
                GroupsIndex = 0;
            }
            fetchGroup();
        }

        private void buttonPrevGroup_Click(object sender, EventArgs e)
        {
            GroupsIndex--;
            if (GroupsIndex < 0)
            {
                GroupsIndex = LoggedInUser.Groups.Count - 1;
            }
            fetchGroup();
        }

        private void fetchFavoriteTeams()
        {
            if (LoggedInUser.FavofriteTeams != null)
            {
                labelFavoriteTeamName.Text = LoggedInUser.FavofriteTeams[TeamsIndex].Name;
                pictureBoxTeam.Image = LoggedInUser.FavofriteTeams[TeamsIndex].ImageNormal;
            }
            else
            {
                labelFavoriteTeamName.Text = "There are no teams to show";
            }
        }

        private void AlbumsInit()
        {
            foreach(Album album in LoggedInUser.Albums)
            {
                comboBoxAlbums.Items.Add(album.Name);
            }
            if (LoggedInUser.Albums.Count != 0)
            {
                comboBoxAlbums.SelectedIndex = 0;

            }
            pictureBoxAlbum.Image = LoggedInUser.Albums[0].CoverPhoto.ImageNormal;
        }

        private void buttonNextTeam_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.FavofriteTeams != null)
            {
                TeamsIndex++;
                if (TeamsIndex >= LoggedInUser.FavofriteTeams.Length)
                {
                    TeamsIndex = 0;
                }
                fetchGroup();
            }

        }

        private void buttonPrevTeam_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.FavofriteTeams != null)
            {
                TeamsIndex--;
                if (TeamsIndex < 0)
                {
                    TeamsIndex = LoggedInUser.FavofriteTeams.Length - 1;
                }
                fetchGroup();
            }
        }

        private void fetchEvents()
        {
            foreach (Event userEvent in LoggedInUser.Events)
            {
                comboBoxEvents.Items.Add(userEvent.Name);
            }

            if (LoggedInUser.Events.Count != 0)
            {
                comboBoxEvents.SelectedIndex = 0;
            }
     
        }

        private void comboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxAlbum.Image = LoggedInUser.Albums[comboBoxAlbums.SelectedIndex].CoverPhoto.ImageNormal;
        }

        private void buttonWikiSerach_Click(object sender, EventArgs e)
        {
            string artistName = "Lady_Gaga";
            FormArtistWiki currentArtists = new FormArtistWiki(artistName);
            currentArtists.ShowDialog();
        private void comboBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxEvent.Image = LoggedInUser.Events[comboBoxEvents.SelectedIndex].ImageNormal;
        }

        private void pictureBoxAlbum_Click(object sender, EventArgs e)
        {

        }
    }
}
