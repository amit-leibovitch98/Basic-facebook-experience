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

        public FormMain()
        {
            InitializeComponent();

            m_FacebookLogicService = new FacebookLogicService();

            Size = new Size(180, 280);
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            m_FacebookLogicService.LoadAppSettings();

            if (m_FacebookLogicService.AppSettings.RememberMe)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = m_FacebookLogicService.AppSettings.WindowSize;
                this.Location = m_FacebookLogicService.AppSettings.WindowLocation;
                this.checkBoxRememberMe.Checked = m_FacebookLogicService.AppSettings.RememberMe;
            
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
                InitInfoAfterLogin();
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
                InitInfoAfterLogin();
            }
            else
            {
                MessageBox.Show(loginFailedErrorMessage, "Login Failed");
            }
        }

        private void InitInfoAfterLogin()
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
            //labelPosts.Text = LoggedInUser.Posts[0].Message;
            fetchGroup();
            fetchPost();
            fetchPage();
            fetchFavoriteTeams();
            fetchEvents();
            fetchAlbums();
            fetchArtist();
        }

        private void fetchPost()
        {
            Post post = m_FacebookLogicService.GetPost();
            displayPost(post);
        }

        private void displayPost(Post post)
        {
            string postText, imgURL;
            m_FacebookLogicService.GetPostTextAndPicture(post, out postText, out imgURL);
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
            m_FacebookLogicService.Logout();
            pictureBoxProfile.Image = null;
            buttonLogin.Text = "Login";
            switchToLoginMode();
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
            this.pictureBoxBulb.Visible = false;
            this.checkBoxRememberMe.Checked = false;
            this.buttonShareQuote.Visible = false;
            this.labelFirendsNumber.Visible = false;
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
            displayPage(page);
        }

        private void displayPage(Page page)
        {
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
            Page team = m_FacebookLogicService.GetFavoriteTeam();
            displayTeam(team);
        }

        private void displayTeam(Page team)
        {
            if (team != null)
            {
                labelFavoriteTeamName.Text = team.Name;
                pictureBoxTeam.Image = team.ImageNormal;
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
                comboBoxAlbums.Items.Add(albumName);
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
                comboBoxEvents.Items.Add(eventName);
            }

            if (eventNames.Count > 0)
            {
                comboBoxEvents.SelectedIndex = 0;
            }  
        }

        private void displayArtist(Artist artist)
        {
            labelArtistsName.Text = artist.Name;
            pictureBoxArtistsPicture.LoadAsync(artist.ImageUrl);
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
            displayArtist(artist);
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
            FormShareQuote formShareQuote = new FormShareQuote(m_FacebookLogicService);
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
