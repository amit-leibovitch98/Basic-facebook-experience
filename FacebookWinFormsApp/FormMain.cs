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
        private FacebookLogicService m_FacebookLogicService;

        private string m_AccessToken;
        public User LoggedInUser { get; set; } = null;
        public LoginResult LoginResult { get; set; }
        public int LikedArtistsIndex { get; set; } = 0;

        public int TeamsIndex { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
        public int AlbumIndex { get; set; } = 0;
        public AppSettings m_AppSettings;
        private QuotesLoader m_quotesLoader;
        private InfoLogic m_infoLogic;
        private List<Page> m_artistsList;
        private string m_FilePath;


        public FormMain()
        {
            InitializeComponent();

            m_FacebookLogicService = new FacebookLogicService();


            Size = new Size(180, 280);
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            //shachar
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"AppSettings.xml");
            m_FilePath = Path.GetFullPath(file);

            if (File.Exists(m_FilePath) && File.ReadAllText(m_FilePath) != "")
            {
                m_AppSettings = AppSettings.LoadFromXmlFile(m_FilePath);
            }
            else
            {
                m_AppSettings = new AppSettings();
            }

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

            m_AppSettings.SaveToXmlFile(m_FilePath);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool success = m_FacebookLogicService.LogIn();
            if (success)
            {
                pictureBoxLogin.Visible = false;
                LoginResult = m_FacebookLogicService.LoginResult; // TODO Delete this!
                InitInfoAfterLogin();
            }
            else
            {
                MessageBox.Show(LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void InitInfoAfterLogin()
        {
            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                LoggedInUser = LoginResult.LoggedInUser;
                m_AccessToken = LoginResult.AccessToken;
                fetchUserInfo();
                labelUserName.Text = string.Format("{0}", LoggedInUser.Name);
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
                m_artistsList = m_infoLogic.GetArtistsList(LoggedInUser.LikedPages.ToList());
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
            fetchAlbums();
        }

        private void fetchPost()
        {
            Post post = m_FacebookLogicService.GetPost();
            displayPost(post);
        }

        private void displayPost(Post post)
        {
            string postText, imgURL;
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
            m_AppSettings.SaveToXmlFile(m_FilePath);
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
            Post post = m_FacebookLogicService.GetNextPost();
            displayPost(post);
        }

        private void buttonPrevPost_Click(object sender, EventArgs e)
        {
            Post post = m_FacebookLogicService.GetPreviousPost();
            displayPost(post);
        }

        private void labelLikes_Click(object sender, EventArgs e)
        {
            Post post = m_FacebookLogicService.GetPost();
            FormLikes formLikes = new FormLikes(post);
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
            Group group = m_FacebookLogicService.GetGroup();
            displayGroup(group);
        }

        private void displayGroup(Group group)
        {
            LabelGroupName.Text = group.Name;
            pictureBoxGroup.Image = group.ImageNormal;
            labelGroupDescription.Text = group.Description;
        }

        private void buttonNextGroup_Click(object sender, EventArgs e)
        {
            Group group = m_FacebookLogicService.GetNextGroup();
            displayGroup(group);
        }

        private void buttonPrevGroup_Click(object sender, EventArgs e)
        {
            Group group = m_FacebookLogicService.GetPreviousGroup();
            displayGroup(group);
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

        private void fetchAlbums()
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
            AlbumIndex = 0;
        }

        private void comboBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxEvent.Image = LoggedInUser.Events[comboBoxEvents.SelectedIndex].ImageNormal;
        }

        private void pictureBoxAlbum_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonSerarchMeOnWiki_Click(object sender, EventArgs e)
        {
            string artistsName = m_artistsList[LikedArtistsIndex].Name;
            if(artistsName.Contains(" "))
            {
                artistsName.Replace(" ", "_");
            }
            FormWikiBrowser wiki = new FormWikiBrowser(artistsName);
            wiki.ShowDialog();
        }

        private void buttonArtistsPrev_Click(object sender, EventArgs e)
        {
            if (m_artistsList != null)
            {
                LikedArtistsIndex--;
                if (LikedArtistsIndex < 0)
                {
                    LikedArtistsIndex = m_artistsList.Count - 1;
                }
                fetchGroup();
            }
        }

        private void buttonArtistsNext_Click(object sender, EventArgs e)
        {
        if (m_artistsList != null)
            {
                LikedArtistsIndex++;
                if (LikedArtistsIndex >= m_artistsList.Count)
                {
                    LikedArtistsIndex = 0;
                }
                fetchGroup();
            }
        }
    }
}
