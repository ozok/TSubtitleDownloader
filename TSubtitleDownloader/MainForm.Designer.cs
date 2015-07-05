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
            this.components = new System.ComponentModel.Container();
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.openVideoDialog = new System.Windows.Forms.OpenFileDialog();
            this.DownloadSubtitlesBtn = new System.Windows.Forms.Button();
            this.SubtitleDownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.LanguageList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SkipExistingSubBtn = new System.Windows.Forms.CheckBox();
            this.AddMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TopBar = new System.Windows.Forms.Panel();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.TotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.LogList = new System.Windows.Forms.ListBox();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.LogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
            this.WaitPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.AddMenu.SuspendLayout();
            this.TopBar.SuspendLayout();
            this.ProgressPanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.LogMenu.SuspendLayout();
            this.WaitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileList
            // 
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.FullRowSelect = true;
            this.FileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FileList.HideSelection = false;
            this.FileList.Location = new System.Drawing.Point(0, 0);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(984, 359);
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
            this.AddFileBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddFileBtn.Location = new System.Drawing.Point(0, 0);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(100, 55);
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
            this.DownloadSubtitlesBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DownloadSubtitlesBtn.Location = new System.Drawing.Point(884, 0);
            this.DownloadSubtitlesBtn.Name = "DownloadSubtitlesBtn";
            this.DownloadSubtitlesBtn.Size = new System.Drawing.Size(100, 55);
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
            // LanguageList
            // 
            this.LanguageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageList.FormattingEnabled = true;
            this.LanguageList.Location = new System.Drawing.Point(466, 28);
            this.LanguageList.Name = "LanguageList";
            this.LanguageList.Size = new System.Drawing.Size(312, 21);
            this.LanguageList.TabIndex = 6;
            this.LanguageList.SelectedIndexChanged += new System.EventHandler(this.LanguageList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Subtitle language:";
            // 
            // SkipExistingSubBtn
            // 
            this.SkipExistingSubBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkipExistingSubBtn.AutoSize = true;
            this.SkipExistingSubBtn.Location = new System.Drawing.Point(466, 5);
            this.SkipExistingSubBtn.Name = "SkipExistingSubBtn";
            this.SkipExistingSubBtn.Size = new System.Drawing.Size(190, 17);
            this.SkipExistingSubBtn.TabIndex = 8;
            this.SkipExistingSubBtn.Text = "Don\'t download if file already exists";
            this.SkipExistingSubBtn.UseVisualStyleBackColor = true;
            this.SkipExistingSubBtn.CheckedChanged += new System.EventHandler(this.SkipExistingSubBtn_CheckedChanged);
            // 
            // AddMenu
            // 
            this.AddMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.addFolderTreeToolStripMenuItem});
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(159, 70);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // addFolderTreeToolStripMenuItem
            // 
            this.addFolderTreeToolStripMenuItem.Name = "addFolderTreeToolStripMenuItem";
            this.addFolderTreeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addFolderTreeToolStripMenuItem.Text = "Add Folder Tree";
            this.addFolderTreeToolStripMenuItem.Click += new System.EventHandler(this.addFolderTreeToolStripMenuItem_Click);
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.ShowNewFolderButton = false;
            // 
            // TopBar
            // 
            this.TopBar.Controls.Add(this.StopBtn);
            this.TopBar.Controls.Add(this.AddFileBtn);
            this.TopBar.Controls.Add(this.DownloadSubtitlesBtn);
            this.TopBar.Controls.Add(this.label1);
            this.TopBar.Controls.Add(this.LanguageList);
            this.TopBar.Controls.Add(this.SkipExistingSubBtn);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(984, 55);
            this.TopBar.TabIndex = 9;
            // 
            // StopBtn
            // 
            this.StopBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(784, 0);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(100, 55);
            this.StopBtn.TabIndex = 9;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Controls.Add(this.ScoreLabel);
            this.ProgressPanel.Controls.Add(this.TotalProgressBar);
            this.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressPanel.Location = new System.Drawing.Point(0, 551);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(984, 29);
            this.ProgressPanel.TabIndex = 10;
            // 
            // TotalProgressBar
            // 
            this.TotalProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TotalProgressBar.Location = new System.Drawing.Point(0, 16);
            this.TotalProgressBar.Name = "TotalProgressBar";
            this.TotalProgressBar.Size = new System.Drawing.Size(984, 13);
            this.TotalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TotalProgressBar.TabIndex = 5;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScoreLabel.Location = new System.Drawing.Point(0, 3);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(216, 13);
            this.ScoreLabel.TabIndex = 6;
            this.ScoreLabel.Text = "Success: 0 / Fail: 0 / Processed:0 / Total: 0";
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.LogList);
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogPanel.Location = new System.Drawing.Point(0, 414);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(984, 137);
            this.LogPanel.TabIndex = 11;
            // 
            // LogList
            // 
            this.LogList.ContextMenuStrip = this.LogMenu;
            this.LogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogList.FormattingEnabled = true;
            this.LogList.Location = new System.Drawing.Point(0, 0);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(984, 137);
            this.LogList.TabIndex = 1;
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.WaitPanel);
            this.ListPanel.Controls.Add(this.FileList);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPanel.Location = new System.Drawing.Point(0, 55);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(984, 359);
            this.ListPanel.TabIndex = 12;
            // 
            // LogMenu
            // 
            this.LogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.clearLogToolStripMenuItem});
            this.LogMenu.Name = "LogMenu";
            this.LogMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // saveLogDialog
            // 
            this.saveLogDialog.DefaultExt = "txt";
            this.saveLogDialog.Filter = "Text Files|*.txt";
            // 
            // WaitPanel
            // 
            this.WaitPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaitPanel.Controls.Add(this.label2);
            this.WaitPanel.Location = new System.Drawing.Point(309, 111);
            this.WaitPanel.Name = "WaitPanel";
            this.WaitPanel.Size = new System.Drawing.Size(200, 100);
            this.WaitPanel.TabIndex = 2;
            this.WaitPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 98);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please wait...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 580);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.ProgressPanel);
            this.Controls.Add(this.TopBar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSubtitleDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.AddMenu.ResumeLayout(false);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.ListPanel.ResumeLayout(false);
            this.LogMenu.ResumeLayout(false);
            this.WaitPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.OpenFileDialog openVideoDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button DownloadSubtitlesBtn;
        private System.ComponentModel.BackgroundWorker SubtitleDownloadWorker;
        private System.Windows.Forms.ComboBox LanguageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SkipExistingSubBtn;
        private System.Windows.Forms.ContextMenuStrip AddMenu;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderTreeToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog openFolderDialog;
        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.ProgressBar TotalProgressBar;
        private System.Windows.Forms.Panel LogPanel;
        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.ContextMenuStrip LogMenu;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveLogDialog;
        private System.Windows.Forms.Panel WaitPanel;
        private System.Windows.Forms.Label label2;
    }
}

