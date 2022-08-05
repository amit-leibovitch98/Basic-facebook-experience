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
        public User LoggedInUser { get; set; }
        public LoginResult LoginResult { get; set; }


        
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
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
                    "public_profile"
                    /// add any relevant permissions
                    );

            buttonLogin.Text = $"Logged in as {LoginResult.LoggedInUser.Name}";

            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                LoggedInUser = LoginResult.LoggedInUser;
                m_AccessToken = LoginResult.AccessToken;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(LoggedInUser.PictureNormalURL);

            fetchFriendsImages();

        /*  if (LoggedInUser.Posts.Count > 0)
            {
                textBoxStatus.Text = LoggedInUser.Posts[0].Message;
            }*/
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
			FacebookService.LogoutWithUI();
            pictureBoxProfile.Image = null;
			buttonLogin.Text = "Login";
            LoginResult = null;
        }

        private void fetchFriendsImages()
        {
            foreach (User friend in LoggedInUser.Friends)
            {
                imageListFriends.Images.Add(friend.ImageNormal); 
            }

            pictureBoxFriends.Image = imageListFriends.Images[0];
        }

        private void buttonNextFriendImage_Click(object sender, EventArgs e)
        {
            
        }


    }
}
