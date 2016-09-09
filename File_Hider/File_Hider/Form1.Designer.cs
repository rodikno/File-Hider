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
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hideUnhideButton = new System.Windows.Forms.Button();
            this.ShowHiddenFileButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Выберите папку со скрытым файлом";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите каталог со скрытым файлом";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // hideUnhideButton
            // 
            this.hideUnhideButton.Location = new System.Drawing.Point(25, 100);
            this.hideUnhideButton.Name = "hideUnhideButton";
            this.hideUnhideButton.Size = new System.Drawing.Size(174, 54);
            this.hideUnhideButton.TabIndex = 4;
            this.hideUnhideButton.Text = "Скрыть файл";
            this.hideUnhideButton.UseVisualStyleBackColor = true;
            this.hideUnhideButton.Click += new System.EventHandler(this.HideFileButton_Click);
            // 
            // ShowHiddenFileButton
            // 
            this.ShowHiddenFileButton.Location = new System.Drawing.Point(264, 100);
            this.ShowHiddenFileButton.Name = "ShowHiddenFileButton";
            this.ShowHiddenFileButton.Size = new System.Drawing.Size(159, 54);
            this.ShowHiddenFileButton.TabIndex = 5;
            this.ShowHiddenFileButton.Text = "Показать файл";
            this.ShowHiddenFileButton.UseVisualStyleBackColor = true;
            this.ShowHiddenFileButton.Click += new System.EventHandler(this.ShowHiddenFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 179);
            this.Controls.Add(this.ShowHiddenFileButton);
            this.Controls.Add(this.hideUnhideButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Text Hider v0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button hideUnhideButton;
    }
}

