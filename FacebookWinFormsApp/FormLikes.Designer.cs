namespace BasicFacebookFeatures
{
    partial class FormLikes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLikes));
            this.listBoxLikes = new System.Windows.Forms.ListBox();
            this.labelLikesError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLikes
            // 
            this.listBoxLikes.FormattingEnabled = true;
            this.listBoxLikes.Location = new System.Drawing.Point(4, 31);
            this.listBoxLikes.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLikes.Name = "listBoxLikes";
            this.listBoxLikes.Size = new System.Drawing.Size(194, 225);
            this.listBoxLikes.TabIndex = 0;
            // 
            // labelLikesError
            // 
            this.labelLikesError.AutoSize = true;
            this.labelLikesError.ForeColor = System.Drawing.Color.Red;
            this.labelLikesError.Location = new System.Drawing.Point(49, 9);
            this.labelLikesError.Name = "labelLikesError";
            this.labelLikesError.Size = new System.Drawing.Size(102, 13);
            this.labelLikesError.TabIndex = 1;
            this.labelLikesError.Text = "Could not load likes.";
            this.labelLikesError.Visible = false;
            // 
            // FormLikes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 260);
            this.Controls.Add(this.labelLikesError);
            this.Controls.Add(this.listBoxLikes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLikes";
            this.Text = "Likes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLikes;
        private System.Windows.Forms.Label labelLikesError;
    }
}