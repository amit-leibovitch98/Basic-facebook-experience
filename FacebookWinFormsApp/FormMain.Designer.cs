namespace BasicFacebookFeatures
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabWall = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLikesIcon = new System.Windows.Forms.PictureBox();
            this.labelPostComments = new System.Windows.Forms.Label();
            this.labelPostLikes = new System.Windows.Forms.Label();
            this.pictureBoxPostImg = new System.Windows.Forms.PictureBox();
            this.buttonPrevPost = new System.Windows.Forms.Button();
            this.buttonNextPost = new System.Windows.Forms.Button();
            this.labelPosts = new System.Windows.Forms.Label();
            this.TabLikedPages = new System.Windows.Forms.TabPage();
            this.labelPageCategory = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelPageLikes = new System.Windows.Forms.Label();
            this.buttonPrevPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.pictureBoxPageLogo = new System.Windows.Forms.PictureBox();
            this.labelPageName = new System.Windows.Forms.Label();
            this.pictureBoxPageCover = new System.Windows.Forms.PictureBox();
            this.TabGroups = new System.Windows.Forms.TabPage();
            this.TabFriends = new System.Windows.Forms.TabPage();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.imageListPageUploadedPictures = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabControl.SuspendLayout();
            this.TabWall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikesIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostImg)).BeginInit();
            this.TabLikedPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPageLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPageCover)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogin.Location = new System.Drawing.Point(12, 141);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(144, 28);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogout.Location = new System.Drawing.Point(12, 177);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(144, 28);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(12, 7);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(144, 125);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 53;
            this.pictureBoxProfile.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabWall);
            this.tabControl.Controls.Add(this.TabLikedPages);
            this.tabControl.Controls.Add(this.TabGroups);
            this.tabControl.Controls.Add(this.TabFriends);
            this.tabControl.Location = new System.Drawing.Point(167, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(584, 522);
            this.tabControl.TabIndex = 57;
            this.tabControl.Visible = false;
            // 
            // TabWall
            // 
            this.TabWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.TabWall.Controls.Add(this.checkedListBox1);
            this.TabWall.Controls.Add(this.pictureBox1);
            this.TabWall.Controls.Add(this.pictureBoxLikesIcon);
            this.TabWall.Controls.Add(this.labelPostComments);
            this.TabWall.Controls.Add(this.labelPostLikes);
            this.TabWall.Controls.Add(this.pictureBoxPostImg);
            this.TabWall.Controls.Add(this.buttonPrevPost);
            this.TabWall.Controls.Add(this.buttonNextPost);
            this.TabWall.Controls.Add(this.labelPosts);
            this.TabWall.Location = new System.Drawing.Point(4, 22);
            this.TabWall.Name = "TabWall";
            this.TabWall.Padding = new System.Windows.Forms.Padding(3);
            this.TabWall.Size = new System.Drawing.Size(576, 496);
            this.TabWall.TabIndex = 0;
            this.TabWall.Text = "Wall";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(377, 356);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 66;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(366, 343);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxLikesIcon
            // 
            this.pictureBoxLikesIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLikesIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLikesIcon.Image")));
            this.pictureBoxLikesIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLikesIcon.InitialImage")));
            this.pictureBoxLikesIcon.Location = new System.Drawing.Point(70, 345);
            this.pictureBoxLikesIcon.Name = "pictureBoxLikesIcon";
            this.pictureBoxLikesIcon.Size = new System.Drawing.Size(27, 27);
            this.pictureBoxLikesIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLikesIcon.TabIndex = 64;
            this.pictureBoxLikesIcon.TabStop = false;
            // 
            // labelPostComments
            // 
            this.labelPostComments.AutoSize = true;
            this.labelPostComments.BackColor = System.Drawing.Color.Transparent;
            this.labelPostComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPostComments.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPostComments.Location = new System.Drawing.Point(404, 348);
            this.labelPostComments.Name = "labelPostComments";
            this.labelPostComments.Size = new System.Drawing.Size(86, 20);
            this.labelPostComments.TabIndex = 63;
            this.labelPostComments.Text = "Comments";
            // 
            // labelPostLikes
            // 
            this.labelPostLikes.AutoSize = true;
            this.labelPostLikes.BackColor = System.Drawing.Color.Transparent;
            this.labelPostLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPostLikes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPostLikes.Location = new System.Drawing.Point(98, 348);
            this.labelPostLikes.Name = "labelPostLikes";
            this.labelPostLikes.Size = new System.Drawing.Size(46, 20);
            this.labelPostLikes.TabIndex = 62;
            this.labelPostLikes.Text = "Likes";
            this.labelPostLikes.Click += new System.EventHandler(this.labelLikes_Click);
            // 
            // pictureBoxPostImg
            // 
            this.pictureBoxPostImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPostImg.Location = new System.Drawing.Point(46, 95);
            this.pictureBoxPostImg.Name = "pictureBoxPostImg";
            this.pictureBoxPostImg.Size = new System.Drawing.Size(491, 199);
            this.pictureBoxPostImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPostImg.TabIndex = 61;
            this.pictureBoxPostImg.TabStop = false;
            // 
            // buttonPrevPost
            // 
            this.buttonPrevPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonPrevPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonPrevPost.ForeColor = System.Drawing.Color.White;
            this.buttonPrevPost.Location = new System.Drawing.Point(4, 453);
            this.buttonPrevPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrevPost.Name = "buttonPrevPost";
            this.buttonPrevPost.Size = new System.Drawing.Size(30, 30);
            this.buttonPrevPost.TabIndex = 60;
            this.buttonPrevPost.Text = "<";
            this.buttonPrevPost.UseVisualStyleBackColor = false;
            this.buttonPrevPost.Click += new System.EventHandler(this.buttonPrevPost_Click);
            // 
            // buttonNextPost
            // 
            this.buttonNextPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonNextPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNextPost.ForeColor = System.Drawing.Color.White;
            this.buttonNextPost.Location = new System.Drawing.Point(541, 453);
            this.buttonNextPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNextPost.Name = "buttonNextPost";
            this.buttonNextPost.Size = new System.Drawing.Size(30, 30);
            this.buttonNextPost.TabIndex = 59;
            this.buttonNextPost.Text = ">";
            this.buttonNextPost.UseVisualStyleBackColor = false;
            this.buttonNextPost.Click += new System.EventHandler(this.buttonNextPost_Click);
            // 
            // labelPosts
            // 
            this.labelPosts.AutoSize = true;
            this.labelPosts.BackColor = System.Drawing.Color.Transparent;
            this.labelPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelPosts.Location = new System.Drawing.Point(41, 31);
            this.labelPosts.MaximumSize = new System.Drawing.Size(500, 30);
            this.labelPosts.Name = "labelPosts";
            this.labelPosts.Size = new System.Drawing.Size(496, 29);
            this.labelPosts.TabIndex = 0;
            this.labelPosts.Text = "********************POSTS********************";
            this.labelPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabLikedPages
            // 
            this.TabLikedPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.TabLikedPages.Controls.Add(this.labelPageCategory);
            this.TabLikedPages.Controls.Add(this.pictureBox2);
            this.TabLikedPages.Controls.Add(this.labelPageLikes);
            this.TabLikedPages.Controls.Add(this.buttonPrevPage);
            this.TabLikedPages.Controls.Add(this.buttonNextPage);
            this.TabLikedPages.Controls.Add(this.pictureBoxPageLogo);
            this.TabLikedPages.Controls.Add(this.labelPageName);
            this.TabLikedPages.Controls.Add(this.pictureBoxPageCover);
            this.TabLikedPages.Location = new System.Drawing.Point(4, 22);
            this.TabLikedPages.Name = "TabLikedPages";
            this.TabLikedPages.Padding = new System.Windows.Forms.Padding(3);
            this.TabLikedPages.Size = new System.Drawing.Size(576, 496);
            this.TabLikedPages.TabIndex = 1;
            this.TabLikedPages.Text = "Liked Pages";
            // 
            // labelPageCategory
            // 
            this.labelPageCategory.AutoSize = true;
            this.labelPageCategory.BackColor = System.Drawing.Color.Transparent;
            this.labelPageCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPageCategory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPageCategory.Location = new System.Drawing.Point(282, 242);
            this.labelPageCategory.Name = "labelPageCategory";
            this.labelPageCategory.Size = new System.Drawing.Size(73, 20);
            this.labelPageCategory.TabIndex = 67;
            this.labelPageCategory.Text = "Category";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(192, 239);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 66;
            this.pictureBox2.TabStop = false;
            // 
            // labelPageLikes
            // 
            this.labelPageLikes.AutoSize = true;
            this.labelPageLikes.BackColor = System.Drawing.Color.Transparent;
            this.labelPageLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPageLikes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPageLikes.Location = new System.Drawing.Point(220, 242);
            this.labelPageLikes.Name = "labelPageLikes";
            this.labelPageLikes.Size = new System.Drawing.Size(46, 20);
            this.labelPageLikes.TabIndex = 65;
            this.labelPageLikes.Text = "Likes";
            // 
            // buttonPrevPage
            // 
            this.buttonPrevPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonPrevPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonPrevPage.ForeColor = System.Drawing.Color.White;
            this.buttonPrevPage.Location = new System.Drawing.Point(4, 457);
            this.buttonPrevPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrevPage.Name = "buttonPrevPage";
            this.buttonPrevPage.Size = new System.Drawing.Size(30, 30);
            this.buttonPrevPage.TabIndex = 62;
            this.buttonPrevPage.Text = "<";
            this.buttonPrevPage.UseVisualStyleBackColor = false;
            this.buttonPrevPage.Click += new System.EventHandler(this.buttonPrevPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNextPage.ForeColor = System.Drawing.Color.White;
            this.buttonNextPage.Location = new System.Drawing.Point(541, 457);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(30, 30);
            this.buttonNextPage.TabIndex = 61;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = false;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // pictureBoxPageLogo
            // 
            this.pictureBoxPageLogo.Location = new System.Drawing.Point(32, 118);
            this.pictureBoxPageLogo.Name = "pictureBoxPageLogo";
            this.pictureBoxPageLogo.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxPageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPageLogo.TabIndex = 1;
            this.pictureBoxPageLogo.TabStop = false;
            // 
            // labelPageName
            // 
            this.labelPageName.AutoSize = true;
            this.labelPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.labelPageName.Location = new System.Drawing.Point(188, 202);
            this.labelPageName.Name = "labelPageName";
            this.labelPageName.Size = new System.Drawing.Size(141, 29);
            this.labelPageName.TabIndex = 0;
            this.labelPageName.Text = "Page Name";
            // 
            // pictureBoxPageCover
            // 
            this.pictureBoxPageCover.Location = new System.Drawing.Point(8, 6);
            this.pictureBoxPageCover.Name = "pictureBoxPageCover";
            this.pictureBoxPageCover.Size = new System.Drawing.Size(562, 161);
            this.pictureBoxPageCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPageCover.TabIndex = 63;
            this.pictureBoxPageCover.TabStop = false;
            // 
            // TabGroups
            // 
            this.TabGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.TabGroups.Location = new System.Drawing.Point(4, 22);
            this.TabGroups.Name = "TabGroups";
            this.TabGroups.Padding = new System.Windows.Forms.Padding(3);
            this.TabGroups.Size = new System.Drawing.Size(576, 496);
            this.TabGroups.TabIndex = 2;
            this.TabGroups.Text = "Groups";
            // 
            // TabFriends
            // 
            this.TabFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.TabFriends.Location = new System.Drawing.Point(4, 22);
            this.TabFriends.Name = "TabFriends";
            this.TabFriends.Padding = new System.Windows.Forms.Padding(3);
            this.TabFriends.Size = new System.Drawing.Size(576, 496);
            this.TabFriends.TabIndex = 3;
            this.TabFriends.Text = "Friends";
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxRememberMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.checkBoxRememberMe.Location = new System.Drawing.Point(12, 178);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(119, 21);
            this.checkBoxRememberMe.TabIndex = 60;
            this.checkBoxRememberMe.Text = "Remember Me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // imageListPageUploadedPictures
            // 
            this.imageListPageUploadedPictures.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListPageUploadedPictures.ImageSize = new System.Drawing.Size(150, 150);
            this.imageListPageUploadedPictures.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 531);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.pictureBoxProfile);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.TabWall.ResumeLayout(false);
            this.TabWall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikesIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostImg)).EndInit();
            this.TabLikedPages.ResumeLayout(false);
            this.TabLikedPages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPageLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPageCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabWall;
        private System.Windows.Forms.TabPage TabLikedPages;
        private System.Windows.Forms.TabPage TabGroups;
        private System.Windows.Forms.Label labelPosts;
        private System.Windows.Forms.Button buttonPrevPost;
        private System.Windows.Forms.Button buttonNextPost;
        private System.Windows.Forms.PictureBox pictureBoxPostImg;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxLikesIcon;
        private System.Windows.Forms.Label labelPostComments;
        private System.Windows.Forms.Label labelPostLikes;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.TabPage TabFriends;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.PictureBox pictureBoxPageLogo;
        private System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.PictureBox pictureBoxPageCover;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelPageLikes;
        private System.Windows.Forms.Label labelPageCategory;
        private System.Windows.Forms.ImageList imageListPageUploadedPictures;
    }
}

