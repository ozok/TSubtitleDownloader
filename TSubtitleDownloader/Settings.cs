using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TSubtitleDownloader
{
    /// <summary>
    /// holds program settings
    /// </summary>
    public class Settings
    {
        public int Language { get; set; }
        public bool IgnoreIfExists { get; set; }
        public string LastDirectory { get; set; }

        public Settings()
        {
            Language = 38; // English
            IgnoreIfExists = false;
            LastDirectory = "";
        }
    }
    /// <summary>
    /// reads and writes program settings to a json file
    /// </summary>
    public class SettingReader
    {
        private string SettingsFilePath { get; set; }

        public SettingReader(string settingsFilePath)
        {
            this.SettingsFilePath = settingsFilePath;
        }

        public Settings LoadSettings()
        {
            var jsonStr = System.IO.File.ReadAllText(SettingsFilePath, Encoding.UTF8);
            Settings settings = JsonConvert.DeserializeObject<Settings>(jsonStr);
            return settings;
        }

        public void SaveSettings(Settings settings)
        {
            var jsonStr = JsonConvert.SerializeObject(settings);
            System.IO.File.WriteAllText(SettingsFilePath, jsonStr, Encoding.UTF8);
        }
    }
}
