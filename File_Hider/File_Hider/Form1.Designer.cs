namespace File_Hider
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.hideUnhideButton = new System.Windows.Forms.Button();
            this.ShowHiddenFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Выберите папку со скрытым файлом";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // hideUnhideButton
            // 
            this.hideUnhideButton.Location = new System.Drawing.Point(42, 27);
            this.hideUnhideButton.Name = "hideUnhideButton";
            this.hideUnhideButton.Size = new System.Drawing.Size(174, 54);
            this.hideUnhideButton.TabIndex = 4;
            this.hideUnhideButton.Text = "Скрыть файл";
            this.hideUnhideButton.UseVisualStyleBackColor = true;
            this.hideUnhideButton.Click += new System.EventHandler(this.HideFileButton_Click);
            // 
            // ShowHiddenFileButton
            // 
            this.ShowHiddenFileButton.Location = new System.Drawing.Point(254, 27);
            this.ShowHiddenFileButton.Name = "ShowHiddenFileButton";
            this.ShowHiddenFileButton.Size = new System.Drawing.Size(165, 54);
            this.ShowHiddenFileButton.TabIndex = 5;
            this.ShowHiddenFileButton.Text = "Показать файл";
            this.ShowHiddenFileButton.UseVisualStyleBackColor = true;
            this.ShowHiddenFileButton.Click += new System.EventHandler(this.ShowHiddenFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 112);
            this.Controls.Add(this.ShowHiddenFileButton);
            this.Controls.Add(this.hideUnhideButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Text Hider v0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button hideUnhideButton;
        private System.Windows.Forms.Button ShowHiddenFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

