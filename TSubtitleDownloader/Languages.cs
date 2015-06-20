using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSubtitleDownloader
{
    public class Languages
    {
        public Dictionary<string, string> LanguagePairs;

        public Languages(string csvPath)
        {
            LanguagePairs = new Dictionary<string, string>();
            List<string> languageCodes = File.ReadAllLines(csvPath).ToList();
            foreach (string languageCode in languageCodes)
            {
                string[] codes = languageCode.Split(',');
                if (codes.Length == 3)
                {
                    LanguagePairs.Add(codes[2].Replace("\"", "").Trim(),  codes[0].Replace("\"", "").Trim());
                }
            }
        }
    }
}
