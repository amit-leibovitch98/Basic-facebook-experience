using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private string m_AccessToken;
        public User LoggedInUser { get; set; } = null;
        public LoginResult LoginResult { get; set; }
        public int PostsIndex { get; set; } = 37;
        public int PageIndex { get; set; } = 0;
        public AppSettings LoggedInUserAppSettings { get; set; }


        public FormMain()
        {
            InitializeComponent();
            //Shown += new Eve
            Size = new Size(30, 150);
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            LoggedInUserAppSettings = new AppSettings();
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
                    "user_posts",
                    "user_photos",
                    "user_likes"
                    /// add any relevant permissions
                    );
            InitInfoAfterLogin();
        }

        private void InitInfoAfterLogin()
        {
            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                LoggedInUser = LoginResult.LoggedInUser;
                m_AccessToken = LoginResult.AccessToken;
                fetchUserInfo();
                buttonLogin.Text = string.Format("{0} {1}", LoggedInUser.Name, LoggedInUser.LastName);
                buttonLogin.Enabled = false;
                if (checkBoxRememberMe.Checked == true)
                {
                    LoggedInUserAppSettings.RememberMe = true;
                }
                tabControl.Visible = true;
                buttonLogout.Visible = true;
                checkBoxRememberMe.Visible = false;
                Size = new Size(770, 570);
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
            updatePost();
            updatePage();
        }

        private void updatePost()
        {
            string postMassege = string.Empty;
            Post originalPost = LoggedInUser.Posts[PostsIndex];
            if (originalPost.Message != null)
            {
                postMassege = originalPost.Message;
            }
            else if (originalPost.Caption != null)
            {
                postMassege = originalPost.Caption;
            }

            if (originalPost.Type == Post.eType.photo)
            {
                pictureBoxPostImg.LoadAsync(originalPost.PictureURL);
            }
            else
            {
                pictureBoxPostImg.Image = null;
            }
            labelPosts.Text = postMassege;
            labelPostComments.Text = string.Format("({0}) Comments", originalPost.Comments.Count);
            //labelLikes.Text = string.Format("({0}) Likes", originalPost.LikedBy.Count);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            pictureBoxProfile.Image = null;
            buttonLogin.Text = "Login";
            LoginResult = null;
        }

        private void buttonNextPost_Click(object sender, EventArgs e)
        {
            PostsIndex++;
            if (PostsIndex >= LoggedInUser.Posts.Count)
            {
                PostsIndex = 0;
            }
            updatePost();
        }

        private void buttonPrevPost_Click(object sender, EventArgs e)
        {
            PostsIndex--;
            if (PostsIndex < 0)
            {
                PostsIndex = LoggedInUser.Posts.Count - 1;
            }
            updatePost();
        }

        private void labelLikes_Click(object sender, EventArgs e)
        {
            FormLikes formLikes = new FormLikes(LoggedInUser.Posts[PostsIndex]);
            formLikes.ShowDialog();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {

            LoginResult = FacebookService.Connect(LoggedInUserAppSettings.AccessToken);
            InitInfoAfterLogin();
        }

        private void updatePage()
        {
            Page page = LoggedInUser.LikedPages[PageIndex];
            pictureBoxPageLogo.LoadAsync(page.PictureSqaureURL);
            //pictureBoxPageCover.LoadAsync(page.Cover.SourceURL);
            labelPageName.Text = page.Name;
            labelPageCategory.Text = page.Category;
            /*
            foreach (Photo picture in page.Pictures)
            {
                imageListPageUploadedPictures.Images.Add(picture.ImageNormal);
            }
            */
            foreach (Album album in page.Albums)
            {

                foreach (Photo picture in album.Photos)
                {
                    imageListPageUploadedPictures.Images.Add(picture.ImageNormal);
                }
            }
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            PageIndex++;
            if (PageIndex >= LoggedInUser.LikedPages.Count)
            {
                PageIndex = 0;
            }
            updatePage();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            PageIndex--;
            if (PageIndex < 0)
            {
                PageIndex = LoggedInUser.LikedPages.Count - 1;
            }
            updatePage();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            LoggedInUserAppSettings.WindowSize = Size;
            LoggedInUserAppSettings.WindowLocation = Location;
            LoggedInUserAppSettings.AccessToken = m_AccessToken;

            LoggedInUserAppSettings.SaveToFile();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (LoggedInUserAppSettings.RememberMe && !string.IsNullOrEmpty(LoggedInUserAppSettings.AccessToken))
            {
                LoginResult = FacebookService.Connect(LoggedInUserAppSettings.AccessToken);
                InitInfoAfterLogin();
            }

        }
    }
}
