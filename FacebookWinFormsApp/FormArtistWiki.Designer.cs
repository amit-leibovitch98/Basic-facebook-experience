namespace BasicFacebookFeatures
{
    partial class FormArtistWiki
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArtistWiki));
            this.webBrowserForWikiArtists = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserForWikiArtists
            // 
            this.webBrowserForWikiArtists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserForWikiArtists.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserForWikiArtists.Location = new System.Drawing.Point(0, 0);
            this.webBrowserForWikiArtists.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserForWikiArtists.Name = "webBrowserForWikiArtists";
            this.webBrowserForWikiArtists.Size = new System.Drawing.Size(800, 450);
            this.webBrowserForWikiArtists.TabIndex = 0;
            // 
            // FormArtistWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowserForWikiArtists);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormArtistWiki";
            this.Text = "FormArtistWiki";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserForWikiArtists;
    }
}