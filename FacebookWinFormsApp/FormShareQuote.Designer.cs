namespace BasicFacebookFeatures
{
    partial class FormShareQuote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShareQuote));
            this.textBoxToPost = new System.Windows.Forms.TextBox();
            this.buttonShareQuote = new System.Windows.Forms.Button();
            this.labelEditPostMassege = new System.Windows.Forms.Label();
            this.pictureBoxfinger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxfinger)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxToPost
            // 
            this.textBoxToPost.AcceptsReturn = true;
            this.textBoxToPost.AcceptsTab = true;
            this.textBoxToPost.AllowDrop = true;
            this.textBoxToPost.Location = new System.Drawing.Point(12, 49);
            this.textBoxToPost.MaximumSize = new System.Drawing.Size(375, 500);
            this.textBoxToPost.MinimumSize = new System.Drawing.Size(375, 100);
            this.textBoxToPost.Multiline = true;
            this.textBoxToPost.Name = "textBoxToPost";
            this.textBoxToPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxToPost.Size = new System.Drawing.Size(375, 100);
            this.textBoxToPost.TabIndex = 0;
            // 
            // buttonShareQuote
            // 
            this.buttonShareQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.buttonShareQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShareQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonShareQuote.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonShareQuote.Location = new System.Drawing.Point(131, 186);
            this.buttonShareQuote.Name = "buttonShareQuote";
            this.buttonShareQuote.Size = new System.Drawing.Size(112, 35);
            this.buttonShareQuote.TabIndex = 66;
            this.buttonShareQuote.Text = "Post!";
            this.buttonShareQuote.UseVisualStyleBackColor = false;
            this.buttonShareQuote.Click += new System.EventHandler(this.buttonShareQuote_Click);
            // 
            // labelEditPostMassege
            // 
            this.labelEditPostMassege.AutoSize = true;
            this.labelEditPostMassege.BackColor = System.Drawing.Color.Transparent;
            this.labelEditPostMassege.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelEditPostMassege.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.labelEditPostMassege.Location = new System.Drawing.Point(50, 25);
            this.labelEditPostMassege.Name = "labelEditPostMassege";
            this.labelEditPostMassege.Size = new System.Drawing.Size(219, 15);
            this.labelEditPostMassege.TabIndex = 67;
            this.labelEditPostMassege.Text = "You can edit your post before posting it!";
            // 
            // pictureBoxfinger
            // 
            this.pictureBoxfinger.Image = global::BasicFacebookFeatures.Properties.Resources.Untitled_1;
            this.pictureBoxfinger.Location = new System.Drawing.Point(11, 16);
            this.pictureBoxfinger.Name = "pictureBoxfinger";
            this.pictureBoxfinger.Size = new System.Drawing.Size(40, 27);
            this.pictureBoxfinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxfinger.TabIndex = 68;
            this.pictureBoxfinger.TabStop = false;
            // 
            // FormShareQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 233);
            this.Controls.Add(this.pictureBoxfinger);
            this.Controls.Add(this.labelEditPostMassege);
            this.Controls.Add(this.buttonShareQuote);
            this.Controls.Add(this.textBoxToPost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShareQuote";
            this.Text = "Post Quote";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxfinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxToPost;
        private System.Windows.Forms.Button buttonShareQuote;
        private System.Windows.Forms.Label labelEditPostMassege;
        private System.Windows.Forms.PictureBox pictureBoxfinger;
    }
}