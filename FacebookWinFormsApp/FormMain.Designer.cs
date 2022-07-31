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
            this.imageListFriends = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxFriends = new System.Windows.Forms.PictureBox();
            this.buttonNextFriendImage = new System.Windows.Forms.Button();
            this.buttonPrevFriendImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(179, 23);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(12, 41);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(179, 23);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(24, 84);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(138, 139);
            this.pictureBoxProfile.TabIndex = 53;
            this.pictureBoxProfile.TabStop = false;
            // 
            // imageListFriends
            // 
            this.imageListFriends.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFriends.ImageStream")));
            this.imageListFriends.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFriends.Images.SetKeyName(0, "background1.jpg");
            // 
            // pictureBoxFriends
            // 
            this.pictureBoxFriends.Location = new System.Drawing.Point(385, 134);
            this.pictureBoxFriends.Name = "pictureBoxFriends";
            this.pictureBoxFriends.Size = new System.Drawing.Size(213, 196);
            this.pictureBoxFriends.TabIndex = 54;
            this.pictureBoxFriends.TabStop = false;
            // 
            // buttonNextFriendImage
            // 
            this.buttonNextFriendImage.Location = new System.Drawing.Point(567, 307);
            this.buttonNextFriendImage.Name = "buttonNextFriendImage";
            this.buttonNextFriendImage.Size = new System.Drawing.Size(31, 23);
            this.buttonNextFriendImage.TabIndex = 55;
            this.buttonNextFriendImage.Text = ">";
            this.buttonNextFriendImage.UseVisualStyleBackColor = true;
            this.buttonNextFriendImage.Click += new System.EventHandler(this.buttonNextFriendImage_Click);
            // 
            // buttonPrevFriendImage
            // 
            this.buttonPrevFriendImage.Location = new System.Drawing.Point(385, 307);
            this.buttonPrevFriendImage.Name = "buttonPrevFriendImage";
            this.buttonPrevFriendImage.Size = new System.Drawing.Size(31, 23);
            this.buttonPrevFriendImage.TabIndex = 56;
            this.buttonPrevFriendImage.Text = "<";
            this.buttonPrevFriendImage.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 657);
            this.Controls.Add(this.buttonPrevFriendImage);
            this.Controls.Add(this.buttonNextFriendImage);
            this.Controls.Add(this.pictureBoxFriends);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.ImageList imageListFriends;
        private System.Windows.Forms.PictureBox pictureBoxFriends;
        private System.Windows.Forms.Button buttonNextFriendImage;
        private System.Windows.Forms.Button buttonPrevFriendImage;
    }
}

