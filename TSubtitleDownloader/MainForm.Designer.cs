namespace TSubtitleDownloader
{
    partial class MainForm
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
            this.LogList = new System.Windows.Forms.ListBox();
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.openVideoDialog = new System.Windows.Forms.OpenFileDialog();
            this.DownloadSubtitlesBtn = new System.Windows.Forms.Button();
            this.SubtitleDownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.TotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.LanguageList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SkipExistingSubBtn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LogList
            // 
            this.LogList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogList.FormattingEnabled = true;
            this.LogList.Location = new System.Drawing.Point(12, 328);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(841, 95);
            this.LogList.TabIndex = 0;
            // 
            // FileList
            // 
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.FileList.FullRowSelect = true;
            this.FileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FileList.HideSelection = false;
            this.FileList.Location = new System.Drawing.Point(12, 41);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(841, 281);
            this.FileList.TabIndex = 1;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Path";
            this.columnHeader1.Width = 495;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Extension";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Subtitle State";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 134;
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Location = new System.Drawing.Point(12, 12);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(75, 23);
            this.AddFileBtn.TabIndex = 2;
            this.AddFileBtn.Text = "Add Files";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // openVideoDialog
            // 
            this.openVideoDialog.Filter = "Video Files|*.flv;*.m2v;*.avi;*.mkv;*.mpeg;*.mpg;*.mov;*.wmv;*.mp4;*.m4v;*.dat;*." +
    "vob;*.rmvb;*.mts;*.mxf|All Files|*.*";
            this.openVideoDialog.Multiselect = true;
            // 
            // DownloadSubtitlesBtn
            // 
            this.DownloadSubtitlesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadSubtitlesBtn.Location = new System.Drawing.Point(778, 12);
            this.DownloadSubtitlesBtn.Name = "DownloadSubtitlesBtn";
            this.DownloadSubtitlesBtn.Size = new System.Drawing.Size(75, 23);
            this.DownloadSubtitlesBtn.TabIndex = 3;
            this.DownloadSubtitlesBtn.Text = "Download";
            this.DownloadSubtitlesBtn.UseVisualStyleBackColor = true;
            this.DownloadSubtitlesBtn.Click += new System.EventHandler(this.DownloadSubtitlesBtn_Click);
            // 
            // SubtitleDownloadWorker
            // 
            this.SubtitleDownloadWorker.WorkerReportsProgress = true;
            this.SubtitleDownloadWorker.WorkerSupportsCancellation = true;
            this.SubtitleDownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SubtitleDownloadWorker_DoWork);
            // 
            // TotalProgressBar
            // 
            this.TotalProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalProgressBar.Location = new System.Drawing.Point(12, 452);
            this.TotalProgressBar.Name = "TotalProgressBar";
            this.TotalProgressBar.Size = new System.Drawing.Size(841, 13);
            this.TotalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TotalProgressBar.TabIndex = 4;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(12, 436);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(216, 13);
            this.ScoreLabel.TabIndex = 5;
            this.ScoreLabel.Text = "Success: 0 / Fail: 0 / Processed:0 / Total: 0";
            // 
            // LanguageList
            // 
            this.LanguageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageList.FormattingEnabled = true;
            this.LanguageList.Location = new System.Drawing.Point(529, 14);
            this.LanguageList.Name = "LanguageList";
            this.LanguageList.Size = new System.Drawing.Size(243, 21);
            this.LanguageList.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Subtitle language:";
            // 
            // SkipExistingSubBtn
            // 
            this.SkipExistingSubBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkipExistingSubBtn.AutoSize = true;
            this.SkipExistingSubBtn.Location = new System.Drawing.Point(235, 16);
            this.SkipExistingSubBtn.Name = "SkipExistingSubBtn";
            this.SkipExistingSubBtn.Size = new System.Drawing.Size(190, 17);
            this.SkipExistingSubBtn.TabIndex = 8;
            this.SkipExistingSubBtn.Text = "Don\'t download if file already exists";
            this.SkipExistingSubBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 477);
            this.Controls.Add(this.SkipExistingSubBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LanguageList);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.TotalProgressBar);
            this.Controls.Add(this.DownloadSubtitlesBtn);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.LogList);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSubtitleDownloader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.OpenFileDialog openVideoDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button DownloadSubtitlesBtn;
        private System.ComponentModel.BackgroundWorker SubtitleDownloadWorker;
        private System.Windows.Forms.ProgressBar TotalProgressBar;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.ComboBox LanguageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SkipExistingSubBtn;
    }
}

