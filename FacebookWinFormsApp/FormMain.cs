using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private FacebookLogicService m_FacebookLogicService;

        public FormMain()
        {
            InitializeComponent();

            // m_FacebookLogicService = new FacebookLogicService();
            m_FacebookLogicService = Singleton<FacebookLogicService>.Instance;

            Size = new Size(180, 280);
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            m_FacebookLogicService.LoadAppSettings();

            if (m_FacebookLogicService.AppSettings.RememberMe)
            {
                StartPosition = FormStartPosition.Manual;
                Size = m_FacebookLogicService.AppSettings.WindowSize;
                Location = m_FacebookLogicService.AppSettings.WindowLocation;
                checkBoxRememberMe.Checked = m_FacebookLogicService.AppSettings.RememberMe;
            }
            else
            {
                switchToLoginMode();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            bool connectionSuccessful = false;

            base.OnShown(e);

            connectionSuccessful = m_FacebookLogicService.Connect();

            if (connectionSuccessful)
            {
                initInfoAfterLogin();
                pictureBoxLogin.Visible = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            m_FacebookLogicService.SaveSettings(Size, Location);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginFailedErrorMessage;
            bool success = m_FacebookLogicService.Login(out loginFailedErrorMessage);
            if (success)
            {
                pictureBoxLogin.Visible = false;
                initInfoAfterLogin();
            }
            else
            {
                MessageBox.Show(loginFailedErrorMessage, "Login Failed");
            }
        }

        private void initInfoAfterLogin()
        {
            fetchUserInfo();
            labelUserName.Text = m_FacebookLogicService.GetName();
            labelUserName.Visible = true;
            buttonLogin.Visible = false;
            pictureBoxBulb.Visible = false;
            if (checkBoxRememberMe.Checked == true)
            {
                m_FacebookLogicService.AppSettings.RememberMe = true;
            }

            Size = new Size(770, 570);
            tabControl.Visible = true;
            buttonLogout.Visible = true;
            checkBoxRememberMe.Visible = false;
            pictureBoxBulb.Visible = true;
            labelInsperetionalQuote.Visible = true;
            buttonShareQuote.Visible = true;
            labelFirendsNumber.Visible = true;
            labelFirendsNumber.Text = string.Format("({0}) Friends", m_FacebookLogicService.GetFriendsNumber());
            try
            {
                labelInsperetionalQuote.Text = m_FacebookLogicService.GetRandomQuote();
            }
            catch (FileLoadException e)
            {
                labelInsperetionalQuote.Text = e.Message;
            }
        }

        private void fetchUserInfo()
        {
            string profilePictureUrl = m_FacebookLogicService.GetProfilePictureUrl();
            pictureBoxProfile.LoadAsync(profilePictureUrl);
            new Thread(fetchGroup).Start();
            new Thread(fetchPost).Start();
            new Thread(fetchPage).Start();
            new Thread(fetchFavoriteTeams).Start();
            new Thread(fetchEvents).Start();
            new Thread(fetchAlbums).Start();
            new Thread(fetchArtist).Start();
            new Thread(fetchSettings).Start();
        }

        private void fetchPost()
        {
            Post post = m_FacebookLogicService.GetPost();
            this.Invoke(new Action(() => displayPost(post)));
        }

        // shachar
        private void fetchSettings()
        {
            loginResultBindingSource.DataSource = m_FacebookLogicService.CurrentLoginResult;
        }

        private void displayPost(Post i_Post)
        {
            string postText, imgURL;
            m_FacebookLogicService.GetPostTextAndPicture(i_Post, out postText, out imgURL);
            labelPosts.Text = postText;
            labelPostComments.Text = string.Format("({0}) Comments", i_Post.Comments.Count);
            if (imgURL != string.Empty)
            {
                pictureBoxPostImg.LoadAsync(imgURL);
            }
            else
            {
                pictureBoxPostImg.Image = null;
            }

            labelPostLikes.Text = string.Format("({0}) likes", m_FacebookLogicService.getPostLikes(i_Post));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_FacebookLogicService.Logout();
            pictureBoxProfile.Image = null;
            buttonLogin.Text = "Login";
            switchToLoginMode();
        }

        private void switchToLoginMode()
        {
            Size = new Size(180, 280);
            pictureBoxLogin.Visible = false;
            pictureBoxLogin.Visible = true;
            buttonLogin.Visible = true;
            labelUserName.Visible = false;
            buttonLogout.Visible = false;
            labelInsperetionalQuote.Visible = false;
            checkBoxRememberMe.Visible = true;
            pictureBoxBulb.Visible = false;
            checkBoxRememberMe.Checked = false;
            buttonShareQuote.Visible = false;
            labelFirendsNumber.Visible = false;
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

        private void fetchPage()
        {
            Page page = m_FacebookLogicService.GetPage();

            this.Invoke(new Action(() => displayPage(page)));
        }

        private void displayPage(Page i_Page)
        {
            pictureBoxPageLogo.LoadAsync(i_Page.PictureSqaureURL);
            labelPageName.Text = i_Page.Name;
            labelPageCategory.Text = i_Page.Category;
            labelPageLikes.Text = string.Format("({0}) Likes", i_Page.LikesCount);
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            Page page = m_FacebookLogicService.GetNextPage();
            displayPage(page);
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            Page page = m_FacebookLogicService.GetPreviousPage();
            displayPage(page);
        }

        private void fetchGroup()
        {
            Group group = m_FacebookLogicService.GetGroup();
            this.Invoke(new Action(() => displayGroup(group)));
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
            Page team = m_FacebookLogicService.GetFavoriteTeam();
            this.Invoke(new Action(() => displayTeam(team)));
        }

        private void displayTeam(Page i_team)
        {
            if (i_team != null)
            {
                labelFavoriteTeamName.Text = i_team.Name;
                pictureBoxTeam.Image = i_team.ImageNormal;
            }
            else
            {
                labelFavoriteTeamName.Text = "There are no teams to show";
            }
        }

        private void fetchAlbums()
        {
            Album album;
            List<string> albumNames = m_FacebookLogicService.GetAlbumNames();
            foreach (string albumName in albumNames)
            {
                this.Invoke(new Action(() => comboBoxAlbums.Items.Add(albumName)));
            }

            if (albumNames.Count > 0)
            {
                comboBoxAlbums.SelectedIndex = 0;
                album = m_FacebookLogicService.GetAlbumByName(albumNames[0]);
                pictureBoxAlbum.Image = album.CoverPhoto.ImageNormal;
            }
        }

        private void buttonNextTeam_Click(object sender, EventArgs e)
        {
            Page team = m_FacebookLogicService.GetNextFavoriteTeam();
            displayTeam(team);
        }

        private void buttonPrevTeam_Click(object sender, EventArgs e)
        {
            Page team = m_FacebookLogicService.GetPreviousFavoriteTeam();
            displayTeam(team);
        }

        private void fetchEvents()
        {
            List<string> eventNames = m_FacebookLogicService.GetEventNames();
            foreach (string eventName in eventNames)
            {
                this.Invoke(new Action(() => comboBoxEvents.Items.Add(eventName)));
            }

            if (eventNames.Count > 0)
            {
                comboBoxEvents.SelectedIndex = 0;
            }
        }

        private void displayArtist(Artist i_Artist)
        {
            labelArtistsName.Text = i_Artist.Name;
            pictureBoxArtistsPicture.LoadAsync(i_Artist.ImageUrl);
        }

        private void comboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album album = m_FacebookLogicService.GetAlbumByName((string)comboBoxAlbums.SelectedItem);
            if (album != null)
            {
                pictureBoxAlbum.Image = album.CoverPhoto.ImageNormal;
            }
            else
            {
                pictureBoxAlbum.Image = null;
            }
        }

        private void comboBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event userEvent = m_FacebookLogicService.GetEventByName((string)comboBoxEvents.SelectedItem);
            pictureBoxEvent.Image = userEvent.ImageNormal;
        }

        private void fetchArtist()
        {
            bool successFetchingArtist;
            Artist artist = m_FacebookLogicService.GetArtist(out successFetchingArtist);
            if (!successFetchingArtist)
            {
                labelArtistError.Visible = true;
            }
            else
            {
                labelArtistError.Visible = false;
            }

            this.Invoke(new Action(() => displayArtist(artist)));
        }

        private void buttonSerarchMeOnWiki_Click(object sender, EventArgs e)
        {
            bool successFetchingArtist;
            Artist artist = m_FacebookLogicService.GetArtist(out successFetchingArtist);

            FormWikiBrowser wiki = new FormWikiBrowser(artist.WikiUrl);
            wiki.ShowDialog();
        }

        private void buttonArtistsPrev_Click(object sender, EventArgs e)
        {
            Artist artist = m_FacebookLogicService.GetNextArtist();
            if (artist != null)
            {
                displayArtist(artist);
            }
        }

        private void buttonArtistsNext_Click(object sender, EventArgs e)
        {
            Artist artist = m_FacebookLogicService.GetPreviousArtist();
            if (artist != null)
            {
                displayArtist(artist);
            }
        }

        private void buttonShareQuote_Click(object sender, EventArgs e)
        {
            FormShareQuote formShareQuote = new FormShareQuote();
            formShareQuote.ShowDialog();
        }

        private void buttonNextAlbumPhoto_Click(object sender, EventArgs e)
        {
            Photo photo = m_FacebookLogicService.GetAlbumNextPhoto();
            if (photo != null)
            {
                pictureBoxAlbum.Image = photo.ImageNormal;
            }
        }

        private void buttonPrevAlbumPhoto_Click(object sender, EventArgs e)
        {
            Photo photo = m_FacebookLogicService.GetAlbumPreviousPhoto();
            if (photo != null)
            {
                pictureBoxAlbum.Image = photo.ImageNormal;
            }
        }
    }
}
