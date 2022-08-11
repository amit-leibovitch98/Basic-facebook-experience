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
            textBoxToPost = new System.Windows.Forms.TextBox();
            buttonShareQuote = new System.Windows.Forms.Button();
            labelEditPostMassege = new System.Windows.Forms.Label();
            pictureBoxfinger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxfinger)).BeginInit();
            SuspendLayout();
            // 
            // textBoxToPost
            // 
            textBoxToPost.AcceptsReturn = true;
            textBoxToPost.AcceptsTab = true;
            textBoxToPost.AllowDrop = true;
            textBoxToPost.Location = new System.Drawing.Point(12, 49);
            textBoxToPost.MaximumSize = new System.Drawing.Size(375, 500);
            textBoxToPost.MinimumSize = new System.Drawing.Size(375, 100);
            textBoxToPost.Multiline = true;
            textBoxToPost.Name = "textBoxToPost";
            textBoxToPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxToPost.Size = new System.Drawing.Size(375, 100);
            textBoxToPost.TabIndex = 0;
            // 
            // buttonShareQuote
            // 
            buttonShareQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            buttonShareQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonShareQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            buttonShareQuote.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            buttonShareQuote.Location = new System.Drawing.Point(131, 186);
            buttonShareQuote.Name = "buttonShareQuote";
            buttonShareQuote.Size = new System.Drawing.Size(112, 35);
            buttonShareQuote.TabIndex = 66;
            buttonShareQuote.Text = "Post!";
            buttonShareQuote.UseVisualStyleBackColor = false;
            buttonShareQuote.Click += new System.EventHandler(buttonShareQuote_Click);
            // 
            // labelEditPostMassege
            // 
            labelEditPostMassege.AutoSize = true;
            labelEditPostMassege.BackColor = System.Drawing.Color.Transparent;
            labelEditPostMassege.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            labelEditPostMassege.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            labelEditPostMassege.Location = new System.Drawing.Point(50, 25);
            labelEditPostMassege.Name = "labelEditPostMassege";
            labelEditPostMassege.Size = new System.Drawing.Size(216, 15);
            labelEditPostMassege.TabIndex = 67;
            labelEditPostMassege.Text = "You can edit your postbefore posting it!";
            // 
            // pictureBoxfinger
            // 
            pictureBoxfinger.Image = global::BasicFacebookFeatures.Properties.Resources.Untitled_1;
            pictureBoxfinger.Location = new System.Drawing.Point(11, 16);
            pictureBoxfinger.Name = "pictureBoxfinger";
            pictureBoxfinger.Size = new System.Drawing.Size(40, 27);
            pictureBoxfinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxfinger.TabIndex = 68;
            pictureBoxfinger.TabStop = false;
            // 
            // FormShareQuote
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(396, 233);
            Controls.Add(pictureBoxfinger);
            Controls.Add(labelEditPostMassege);
            Controls.Add(buttonShareQuote);
            Controls.Add(textBoxToPost);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            Name = "FormShareQuote";
            Text = "Post Quote";
            ((System.ComponentModel.ISupportInitialize)(pictureBoxfinger)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxToPost;
        private System.Windows.Forms.Button buttonShareQuote;
        private System.Windows.Forms.Label labelEditPostMassege;
        private System.Windows.Forms.PictureBox pictureBoxfinger;
    }
}