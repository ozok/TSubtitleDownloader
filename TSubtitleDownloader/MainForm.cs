using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubtitleDownloader.Core;
using SubtitleDownloader.Implementations.OpenSubtitles;
using SubtitleDownloader.Util;
using System.Threading;

namespace TSubtitleDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<string> _filePathsList = new List<string>();
        private string _progressMessage = string.Empty;
        private bool _stopDownload = false;
        private int _successCounter = 0;
        private int _failCounter = 0;
        private static Languages _languages = new Languages("languages.csv");

        /// <summary>
        /// adds given file to the file list
        /// </summary>
        /// <param name="filePath">full path to the file</param>
        public void AddFileToList(string filePath)
        {
            var listItem = FileList.Items.Add(Path.GetFileName(filePath));
            listItem.SubItems.Add(Path.GetExtension(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            listItem.SubItems.Add(fileInfo.Length.ToString());
            listItem.SubItems.Add("Waiting");
            _filePathsList.Add(filePath);
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
            if (openVideoDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openVideoDialog.FileNames)
                {
                    AddFileToList(fileName);
                }   
            }
        }

        private void DownloadSubtitlesBtn_Click(object sender, EventArgs e)
        {
            if (_filePathsList.Count > 0)
            {
                TotalProgressBar.Maximum = _filePathsList.Count;
                _failCounter = 0;
                _successCounter = 0;
                _stopDownload = false;

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
        }
    }
}
