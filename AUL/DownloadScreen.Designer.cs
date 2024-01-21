namespace AUL
{
    partial class DownloadScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadScreen));
            listBox1 = new ListBox();
            downloadButton = new Button();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 31;
            listBox1.Location = new Point(32, 36);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(240, 314);
            listBox1.TabIndex = 0;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(435, 329);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(150, 46);
            downloadButton.TabIndex = 1;
            downloadButton.Text = "Button";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(278, 36);
            label1.Name = "label1";
            label1.Size = new Size(82, 31);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // DownloadScreen
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 387);
            Controls.Add(label1);
            Controls.Add(downloadButton);
            Controls.Add(listBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DownloadScreen";
            Text = "Download";
            Load += DownloadScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button downloadButton;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}