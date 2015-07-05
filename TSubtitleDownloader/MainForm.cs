using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SubtitleDownloader.Core;
using SubtitleDownloader.Implementations.OpenSubtitles;

namespace TSubtitleDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const bool Portable = false;

        private const string VersionFileUrl =
            "http://sourceforge.net/projects/tsubtitledownloader/files/version.txt/download";
        private const int Version = 1;
        private string _settingsFilePath;
        private Settings _settings;

        private List<string> _filePathsList = new List<string>();
        private string _progressMessage = string.Empty;
        private bool _stopDownload = false;
        private int _successCounter = 0;
        private int _failCounter = 0;
        private static Languages _languages = new Languages("languages.csv");
        private string _appDataFolder;

        private void DisableUi()
        {
            AddFileBtn.Enabled = false;
            SkipExistingSubBtn.Enabled = false;
            LanguageList.Enabled = false;
            DownloadSubtitlesBtn.Enabled = false;
            RemoveBtn.Enabled = false;
            ClearBtn.Enabled = false;
            IntervalEdit.Enabled = false;
            mainMenu.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void EnableUi()
        {
            AddFileBtn.Enabled = true;
            SkipExistingSubBtn.Enabled = true;
            LanguageList.Enabled = true;
            DownloadSubtitlesBtn.Enabled = true;
            RemoveBtn.Enabled = true;
            ClearBtn.Enabled = true;
            IntervalEdit.Enabled = true;
            mainMenu.Enabled = true;
            StopBtn.Enabled = false; 
        }
        /// <summary>
        /// lists all the files matching the extension
        /// </summary>
        /// <param name="folderPath">full folder path</param>
        /// <param name="searchOption">search option</param>
        /// <returns></returns>
        private List<string> ListFiles(string folderPath, SearchOption searchOption)
        {
            List<string> result = new List<string>();

            string[] filters = { "*.flv", "*.m2v", "*.avi", "*.mkv", "*.mpeg", "*.mpg", "*.mov", "*.wmv", "*.mp4", "*.m4v", "*.dat", "*.vob", "*.rmvb", "*.mts", "*.mxf"};

            foreach (string filter in filters)
            {
                // add found file names to array list
                try
                {
                    result.AddRange(Directory.GetFiles(folderPath, filter, searchOption));
                }
                catch (Exception exception)
                {
                    LogEvent(exception.Message);
                }
            }

            return result;
        } 
        /// <summary>
        /// load settings from json file
        /// </summary>
        private void LoadSettings()
        {
            // if settings file does not exits 
            // just create it as empty and create a setting
            // instance which will have default values
            if (!File.Exists(_settingsFilePath))
            {
                File.WriteAllText(_settingsFilePath, "", Encoding.UTF8);
                _settings = new Settings();
            }
            else
            {
                SettingReader settingReader = new SettingReader(_settingsFilePath);
                _settings = settingReader.LoadSettings();
            }
        }
        /// <summary>
        /// saves settings to json file
        /// </summary>
        private void SaveSettings()
        {
            SettingReader settingReader = new SettingReader(_settingsFilePath);
            settingReader.SaveSettings(_settings);
        }

        /// <summary>
        /// adds given file to the file list
        /// </summary>
        /// <param name="filePath">full path to the file</param>
        public void AddFileToList(string filePath)
        {
            try
            {
                var listItem = FileList.Items.Add(Path.GetFileName(filePath));
                listItem.SubItems.Add(Path.GetExtension(filePath));
                FileInfo fileInfo = new FileInfo(filePath);
                listItem.SubItems.Add(fileInfo.Length.ToString());
                listItem.SubItems.Add("Waiting");
                _filePathsList.Add(filePath);
            }
            catch (Exception exception)
            {
                LogEvent(exception.Message);
            }
        }

        /// <summary>
        /// converts video file path to subtitle path
        /// </summary>
        /// <param name="videoPath">full path to the video file</param>
        /// <param name="subtitleExtension">temp subtitle file's extension</param>
        /// <returns></returns>
        private string GenerateSubtitleFileName(string videoPath, string subtitleExtension)
        {
             return Path.GetDirectoryName(videoPath) + (object)Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(videoPath) 
                    + subtitleExtension;    
        }
        /// <summary>
        /// adds an entry to the program log with date
        /// </summary>
        /// <param name="str">entry</param>
        private void LogEvent(string str)
        {
            LogList.Items.Add(String.Format("[{0}]: {1}", DateTime.Now.ToString(), str));
            LogList.SelectedIndex = LogList.Items.Count - 1;
        }

        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            AddMenu.Show(AddFileBtn, new Point(0, AddFileBtn.Height));
        }

        private void DownloadSubtitlesBtn_Click(object sender, EventArgs e)
        {
            if (_filePathsList.Count > 0)
            {
                TotalProgressBar.Maximum = _filePathsList.Count;
                _failCounter = 0;
                _successCounter = 0;
                _stopDownload = false;

                for (int i = 0; i < FileList.Items.Count; i++)
                {
                    FileList.Items[i].SubItems[2].Text = "Waiting";
                    FileList.Items[i].Selected = false;
                }

                DisableUi();
                FileList.Focus();
                SubtitleDownloadWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Please add some video files.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SubtitleDownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // default language is English
            string languageCode = "eng";
            if (_languages.LanguagePairs.ContainsKey(LanguageList.Text))
            {
                languageCode = _languages.LanguagePairs[LanguageList.Text];
            }

            this.Invoke((MethodInvoker)delegate()
            {
                LogEvent("Starting to search for subtitles.");
                LogEvent(String.Format("Searching subtitles in {0} ({1})", LanguageList.Text, languageCode));
            });
            // search for each file in the list
            for (int i = 0; i < _filePathsList.Count; i++)
            {
                if (_stopDownload)
                {
                    break;
                }

                this.Invoke((MethodInvoker)delegate()
                {
                    LogEvent(String.Format("Sleeping for {0}", IntervalEdit.Value));
                    Thread.Sleep(Convert.ToInt32(IntervalEdit.Value));
                });

                // will be used to update interface
                var listItem = FileList.Items[i];
                string filePath = _filePathsList[i];

                this.Invoke((MethodInvoker)delegate()
                {
                    LogEvent(String.Format("Searching for {0}", Path.GetFileName(filePath)));
                    _progressMessage = "Searching...";
                    listItem.SubItems[3].Text = _progressMessage;
                    listItem.EnsureVisible();
                    listItem.Selected = true;
                });
                try
                {

                    // search for the subtitle using file name and language code
                    var downloader = new OpenSubtitlesDownloader();
                    SearchQuery searchQuery = new SearchQuery(Path.GetFileName(filePath))
                    {
                        LanguageCodes = new string[] { languageCode }
                    };
                    List<Subtitle> results = downloader.SearchSubtitles(searchQuery);
                    // update UI about the found subtitles
                    this.Invoke((MethodInvoker)delegate()
                    {
                        LogEvent(String.Format("Found for {0} subtitles for {1}", results.Count, Path.GetFileName(filePath)));
                        _progressMessage = string.Format("Found {0}", results.Count);
                        listItem.SubItems[3].Text = _progressMessage;
                        listItem.EnsureVisible();
                        listItem.Selected = true;
                    });
                    if (results.Count > 0 && !_stopDownload)
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            LogEvent("Downloading subtitle...");
                            _progressMessage = "Downloading";
                            listItem.SubItems[3].Text = _progressMessage;
                        });
                        // download the first subtitle found
                        Subtitle subtitle = results[0];
                        List<FileInfo> subtitleFiles = downloader.SaveSubtitle(subtitle);
                        FileInfo subtitleFile = subtitleFiles[0];
                        // save subtitle with the same name as the video file
                        string outputSubtitleFilePath = GenerateSubtitleFileName(filePath, Path.GetExtension(subtitleFile.FullName));

                        // if user selects to skip when a subtitle is present
                        // just log it.
                        // otherwise, delete existing subtitle file and replace
                        // it with newly downloaded one.
                        if (SkipExistingSubBtn.Checked)
                        {
                            if (!File.Exists(outputSubtitleFilePath))
                            {
                                File.Move(subtitleFile.FullName, outputSubtitleFilePath);  
                                LogEvent(String.Format("Saved to {0}", outputSubtitleFilePath));
                                // update interface
                                _successCounter++;
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    LogEvent(String.Format("Dowloaded for subtitle for {0}", Path.GetFileName(filePath)));
                                    _progressMessage = "Downloaded";
                                    listItem.SubItems[3].Text = _progressMessage;

                                    ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _failCounter+_successCounter, _filePathsList.Count);
                                    TotalProgressBar.Value = i + 1;
                                    listItem.Selected = false;
                                });
                                Thread.Sleep(150);
                            }
                            else
                            {
                                // update interface
                                _failCounter++;
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    LogEvent(String.Format("{0} alread exists, skipped.", Path.GetFileName(outputSubtitleFilePath)));
                                    _progressMessage = "Skipped";
                                    listItem.SubItems[3].Text = _progressMessage;

                                    ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _failCounter + _successCounter, _filePathsList.Count);
                                    TotalProgressBar.Value = i + 1;
                                    listItem.Selected = false;
                                });
                                Thread.Sleep(150);
                                continue;
                            }
                        }
                        else
                        {
                            if (File.Exists(outputSubtitleFilePath))
                            {
                                try
                                {
                                    File.Delete(outputSubtitleFilePath);
                                }
                                catch (Exception ex)
                                {
                                    LogEvent("Error: " + ex.Message);   
                                }
                            }
                            File.Move(subtitleFile.FullName, outputSubtitleFilePath);
                            LogEvent(String.Format("Saved to {0}", outputSubtitleFilePath));
                        }
                        // update interface
                        _successCounter++;
                        this.Invoke((MethodInvoker)delegate()
                        {
                            LogEvent(String.Format("Dowloaded for subtitle for {0}", Path.GetFileName(filePath)));
                            _progressMessage = "Downloaded";
                            listItem.SubItems[3].Text = _progressMessage;

                            ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _failCounter + _successCounter, _filePathsList.Count);
                            TotalProgressBar.Value = i + 1;
                            listItem.Selected = false;
                        });
                        Thread.Sleep(150);
                    }
                    else
                    {
                        // update interface
                        _failCounter++;
                        this.Invoke((MethodInvoker)delegate()
                        {
                            LogEvent(String.Format("Could not find any subtitles for {0}", Path.GetFileName(filePath)));
                            _progressMessage = "Could not find";
                            listItem.SubItems[3].Text = _progressMessage;

                            ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _failCounter + _successCounter, _filePathsList.Count);
                            TotalProgressBar.Value = i + 1;
                            listItem.Selected = false;
                        });
                        Thread.Sleep(150);
                    }
                }
                catch (Exception ex)
                {
                    // update interface
                    _failCounter++;
                    this.Invoke((MethodInvoker)delegate()
                    {
                        LogEvent(String.Format("Error: {0}", ex.Message));
                        _progressMessage = "Error";
                        listItem.SubItems[3].Text = _progressMessage;

                        ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _failCounter+_successCounter, _filePathsList.Count);
                        TotalProgressBar.Value = i + 1;
                        listItem.Selected = false;
                    });
                    Thread.Sleep(150);
                }
            }
            // update interface
            this.Invoke((MethodInvoker)delegate()
            {
                ScoreLabel.Text = String.Format("Success: {0} / Fail: {1} / Processed: {2} / Total: {3}", _successCounter, _failCounter, _filePathsList.Count, _filePathsList.Count);
                EnableUi();
            });
            Thread.Sleep(200);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            // add dropped files to the file list
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                AddFileToList(file);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // populate language combobox
            foreach (var languagePair in _languages.LanguagePairs)
            {
                LanguageList.Items.Add(languagePair.Key);
            }
            LanguageList.SelectedIndex = 38; // English
            if (!Portable)
            {
                _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                        "\\TSubtitleDownloader";
            }
            else
            {
                _appDataFolder = AppDomain.CurrentDomain.BaseDirectory;
            }
            if (!Portable)
            {
                if (!Directory.Exists(_appDataFolder))
                {
                    Directory.CreateDirectory(_appDataFolder);
                } 
            }
            _settingsFilePath = _appDataFolder + "\\settings.json";
            IntervalEdit.Maximum = Int32.MaxValue;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();

            LanguageList.SelectedIndex = _settings.Language;
            SkipExistingSubBtn.Checked = _settings.IgnoreIfExists;
            IntervalEdit.Value = _settings.WaitInterval;
            versionControlThread.RunWorkerAsync();
        }

        private void SkipExistingSubBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (_settings != null)
            {
                _settings.IgnoreIfExists = SkipExistingSubBtn.Checked;
            }
        }

        private void LanguageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_settings != null)
            {
                _settings.Language = LanguageList.SelectedIndex;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openVideoDialog.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false;
                WaitPanel.Left = (this.Width / 2) - (WaitPanel.Width / 2);
                WaitPanel.Top = (this.Height / 2) - (WaitPanel.Height / 2);
                WaitPanel.Visible = true;
                WaitPanel.BringToFront();
                FileList.BeginUpdate();
                WaitPanel.Refresh();
                try
                {
                    foreach (string fileName in openVideoDialog.FileNames)
                    {
                        Application.DoEvents();
                        AddFileToList(fileName);
                    }
                }
                finally
                {
                    WaitPanel.Visible = false;
                    FileList.EndUpdate();
                    this.Enabled = true;
                }
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_settings.LastDirectory))
            {
                openFolderDialog.SelectedPath = _settings.LastDirectory;
            }
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = openFolderDialog.SelectedPath;
                _settings.LastDirectory = folderPath;

                this.Enabled = false;
                WaitPanel.Left = (this.Width / 2) - (WaitPanel.Width / 2);
                WaitPanel.Top = (this.Height / 2) - (WaitPanel.Height / 2);
                WaitPanel.Visible = true;
                WaitPanel.BringToFront();
                FileList.BeginUpdate();
                WaitPanel.Refresh();
                try
                {
                    var files = ListFiles(folderPath, SearchOption.TopDirectoryOnly);
                    foreach (string file in files)
                    {
                        Application.DoEvents();
                        AddFileToList(file);
                    }
                }
                finally
                {
                    WaitPanel.Visible = false;
                    FileList.EndUpdate();
                    this.Enabled = true;
                }
            }
        }

        private void addFolderTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_settings.LastDirectory))
            {
                openFolderDialog.SelectedPath = _settings.LastDirectory;
            }
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = openFolderDialog.SelectedPath;
                _settings.LastDirectory = folderPath;

                this.Enabled = false;
                WaitPanel.Left = (this.Width / 2) - (WaitPanel.Width / 2);
                WaitPanel.Top = (this.Height / 2) - (WaitPanel.Height / 2);
                WaitPanel.Visible = true;
                WaitPanel.BringToFront();
                FileList.BeginUpdate();
                WaitPanel.Refresh();
                try
                {
                    var files = ListFiles(folderPath, SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        Application.DoEvents();
                        AddFileToList(file);
                    }
                }
                finally
                {
                    WaitPanel.Visible = false;
                    FileList.EndUpdate();
                    this.Enabled = true;
                }
            }
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogList.Items.Clear();
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LogList.Items.Count < 1)
            {
                return;
            }
            if (saveLogDialog.ShowDialog() == DialogResult.OK)
            {
               File.WriteAllLines(saveLogDialog.FileName, new string[]{LogList.Items.ToString()}, Encoding.UTF8);
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            _stopDownload = true;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count > 0)
            {
                if (MessageBox.Show("Clear the file list?", "TSubtitleDownloader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FileList.Items.Clear();
                    _filePathsList.Clear();
                }
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count > 0)
            {
                for (int i = FileList.Items.Count; i-- > 0; )
                {
                    if (FileList.Items[i].Selected)
                    {
                        _filePathsList.RemoveAt(i);
                        FileList.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void IntervalEdit_ValueChanged(object sender, EventArgs e)
        {
            if (_settings != null)
            {
                _settings.WaitInterval =  Convert.ToInt32(IntervalEdit.Value);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void versionControlThread_DoWork(object sender, DoWorkEventArgs e)
        {
            var contents = new System.Net.WebClient().DownloadString(VersionFileUrl).Trim();
            try
            {
                int newVersion = Convert.ToInt32(contents);
                if (newVersion > Version)
                {
                    this.Invoke((MethodInvoker) delegate()
                    {
                        if (
                            MessageBox.Show("There is a new version. Would you like to download it?", "New version",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://sourceforge.net/projects/tsubtitledownloader/");
                        }

                    });
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
