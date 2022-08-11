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
            listBoxLikes = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // listBoxLikes
            // 
            listBoxLikes.FormattingEnabled = true;
            listBoxLikes.ItemHeight = 16;
            listBoxLikes.Location = new System.Drawing.Point(6, 6);
            listBoxLikes.Name = "listBoxLikes";
            listBoxLikes.Size = new System.Drawing.Size(258, 308);
            listBoxLikes.TabIndex = 0;
            // 
            // FormLikes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(272, 320);
            Controls.Add(listBoxLikes);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormLikes";
            Text = "Likes";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLikes;
    }
}